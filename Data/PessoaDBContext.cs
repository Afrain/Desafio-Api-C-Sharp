using Microsoft.EntityFrameworkCore;
using ProjetoCadastroPessoa.Data.Map;
using ProjetoCadastroPessoa.Models;

namespace ProjetoCadastroPessoa.Data
{
    public class PessoaDBContext : DbContext
    {
        public PessoaDBContext(DbContextOptions<PessoaDBContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
