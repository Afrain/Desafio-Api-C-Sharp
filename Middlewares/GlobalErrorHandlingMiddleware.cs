using ProjetoCadastroPessoa.Exceptions;
using System.Data;
using System.Net;
using System.Text.Json;

namespace ProjetoCadastroPessoa.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext) 
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            HttpStatusCode statusCode;
            string? stackTrace;
            string? mensagem;
            var exceptionType = exception.GetType();

            if (exceptionType == typeof(DBConcurrencyException))
            {
                mensagem = exception.Message;
                statusCode = HttpStatusCode.BadRequest;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(NotFoundException))
            {
                mensagem = exception.Message;
                statusCode = HttpStatusCode.NotFound;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(UsuarioOuSenhaInvalidaException))
            {
                mensagem = exception.Message;
                statusCode = HttpStatusCode.BadRequest;
                stackTrace = exception.StackTrace;
            }
            else
            {
                mensagem = exception.Message;
                statusCode = HttpStatusCode.InternalServerError;
                stackTrace = exception.StackTrace;
            }
            var result = JsonSerializer.Serialize(new { statusCode, mensagem, stackTrace });
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int) statusCode;
            return httpContext.Response.WriteAsync(result);

        }
    }
}
