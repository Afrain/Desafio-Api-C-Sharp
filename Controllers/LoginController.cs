using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoCadastroPessoa.Exceptions;
using ProjetoCadastroPessoa.Models;
using ProjetoCadastroPessoa.Models.DTOs;
using ProjetoCadastroPessoa.Repository;
using ProjetoCadastroPessoa.Services;

namespace ProjetoCadastroPessoa.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        [Route("api/login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Login([FromBody] UserDTO userDTO)
        {
            User user = DtoToObjUser(userDTO);
            var usuario = UserRepository.Get(user.Email, user.Senha);

            if (usuario == null)
            {
                throw new UsuarioOuSenhaInvalidaException("Usuário ou senha invalidos!");
            }

            var token = TokenService.GeraToken(usuario);
            usuario.Senha = "";

            return new 
            {
                usuario = usuario,
                token = token
            };
        }

        private User DtoToObjUser(UserDTO userDTO)
        {
            User user = new User()
            { 
                Email = userDTO.Email,
                Senha = userDTO.Senha,
            };
            return user;
        }
    }
}
