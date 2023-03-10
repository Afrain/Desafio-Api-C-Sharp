using System.ComponentModel.DataAnnotations;

namespace ProjetoCadastroPessoa.Models.DTOs
{
    public class UserDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
