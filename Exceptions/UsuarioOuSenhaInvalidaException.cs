namespace ProjetoCadastroPessoa.Exceptions
{
    public class UsuarioOuSenhaInvalidaException : Exception
    {
        public UsuarioOuSenhaInvalidaException(string mensagem) : base(mensagem) { }
    }
}
