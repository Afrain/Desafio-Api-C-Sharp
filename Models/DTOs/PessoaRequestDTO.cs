using System.ComponentModel.DataAnnotations;

namespace ProjetoCadastroPessoa.Models.DTOs
{
    public class PessoaRequestDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "UF é obrigatório!")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "Data de Nascimento é obrigatório!")]
        public DateTime DataNascimento { get; set; }
    }
}
