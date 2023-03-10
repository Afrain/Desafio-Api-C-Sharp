using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoCadastroPessoa.Models;
using ProjetoCadastroPessoa.Models.DTOs;
using ProjetoCadastroPessoa.Repository.Inferfaces;

namespace ProjetoCadastroPessoa.Controllers
{
    [Route("api/pessoas")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN, USER")]
        public async Task<ActionResult<List<Pessoa>>> BuscarTodasPessoas()
        {
            List<Pessoa> pessoas = await _pessoaRepository.BuscarTodasPessoas();
            return Ok(pessoas);
        }

        [HttpGet("UF/{uf}")]
        //[Authorize(Roles = "ADMIN, USER")]
        public async Task<ActionResult<List<Pessoa>>> BuscarTodasPessoasUF(string uf)
        {
            List<Pessoa> pessoas = await _pessoaRepository.BuscarTodasPessoasUF(uf);
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN, USER")]
        public async Task<ActionResult<Pessoa>> BuscarPorId(int id)
        {
            Pessoa pessoa = await _pessoaRepository.BuscarPorId(id);
            return Ok(pessoa);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Pessoa>> Salvar([FromBody] PessoaRequestDTO pessoaRequestDTO) 
        {
            Pessoa pessoa = DtoToObjPessoa(pessoaRequestDTO);
            Pessoa pessoaSalva = await _pessoaRepository.Salvar(pessoa);
            return StatusCode(StatusCodes.Status201Created, pessoaSalva);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Pessoa>> Atualizar([FromBody] PessoaRequestDTO pessoaRequestDTO, int id) 
        { 
            Pessoa pessoa = DtoToObjPessoa(pessoaRequestDTO);
            pessoa.Id = id;
            Pessoa pessoaAtualizada = await _pessoaRepository.Atualizar(pessoa, id);
            return StatusCode(StatusCodes.Status200OK, pessoaAtualizada);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Excluir(int id) 
        {
            await _pessoaRepository.Excluir(id);
            return NoContent();
        }

        private Pessoa DtoToObjPessoa(PessoaRequestDTO pessoaRequestDTO) 
        {
            Pessoa pessoa = new Pessoa()
            {
                Nome = pessoaRequestDTO.Nome,
                Cpf = pessoaRequestDTO.Cpf,
                Uf = pessoaRequestDTO.Uf.ToUpper(),
                DataNascimento = pessoaRequestDTO.DataNascimento
            };

            return pessoa;
        }
    }
}
