using Microsoft.EntityFrameworkCore;
using ProjetoCadastroPessoa.Data;
using ProjetoCadastroPessoa.Exceptions;
using ProjetoCadastroPessoa.Models;
using ProjetoCadastroPessoa.Repository.Inferfaces;

namespace ProjetoCadastroPessoa.Repository
{
    public class PessoaRepository : IPessoaRepository
    {

        private readonly PessoaDBContext _dbContext;

        public PessoaRepository(PessoaDBContext pessoaDBContext)
        {
            _dbContext = pessoaDBContext;
        }

        public async Task<List<Pessoa>> BuscarTodasPessoas()
        {
            return await _dbContext.Pessoas.ToListAsync();
        }

        public Task<List<Pessoa>> BuscarTodasPessoasUF(string uf)
        {
            return Task.FromResult(_dbContext.Pessoas.Where(p => p.Uf.Contains(uf)).ToList());
        }

        public async Task<Pessoa> BuscarPorId(int id)
        {
            Pessoa pessoaBuscada = await _dbContext.Pessoas.FirstOrDefaultAsync(pessoa => pessoa.Id == id);
            
            return pessoaBuscada == null 
                ? throw new NotFoundException($"Usuário com ID: {id} não foi encontrado!")
                : pessoaBuscada;
        }

        public async Task<Pessoa> Salvar(Pessoa pessoa)
        {
            await _dbContext.Pessoas.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();
            return pessoa;
        }

        public async Task<Pessoa> Atualizar(Pessoa pessoa, int id)
        {
            Pessoa pessoaBuscada = await BuscarPorId(id);
            
            pessoaBuscada.Nome = pessoa.Nome;
            pessoaBuscada.Cpf = pessoa.Cpf;
            pessoaBuscada.Uf = pessoa.Uf;
            pessoaBuscada.DataNascimento = pessoa.DataNascimento;

            _dbContext.Update(pessoaBuscada);
            await _dbContext.SaveChangesAsync();

            return pessoaBuscada;
        }

        public async Task<bool> Excluir(int id)
        {
            Pessoa pessoaBuscada = await BuscarPorId(id);
           
            _dbContext.Pessoas.Remove(pessoaBuscada);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
