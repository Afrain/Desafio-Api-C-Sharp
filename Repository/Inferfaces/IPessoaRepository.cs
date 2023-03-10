using ProjetoCadastroPessoa.Models;

namespace ProjetoCadastroPessoa.Repository.Inferfaces
{
    public interface IPessoaRepository
    {
        Task<List<Pessoa>> BuscarTodasPessoas();

        Task<List<Pessoa>> BuscarTodasPessoasUF(string uf);

        Task<Pessoa> BuscarPorId(int id);

        Task<Pessoa> Salvar(Pessoa pessoa);

        Task<Pessoa> Atualizar(Pessoa pessoa, int id);

        Task<bool> Excluir(int id);
    }
}
