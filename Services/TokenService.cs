using Microsoft.IdentityModel.Tokens;
using ProjetoCadastroPessoa.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetoCadastroPessoa.Services
{
    public static class TokenService
    {
        public static string GeraToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("s,f/b(j10<b:&vt!uq/rh4|hlh:0^cz]6l3[@#{,yy%+a<z>])}`f;v5):3ca9y");
            var tokenDescripton = new SecurityTokenDescriptor() 
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)   
            };
            var token = tokenHandler.CreateToken(tokenDescripton);
            return tokenHandler.WriteToken(token);
        }
    }
}
