using API_Alunos.Models;
using API_Alunos.Services.Aluno;
using Microsoft.AspNetCore.Mvc;

namespace API_Alunos.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<TbAluno>>> GetAluno([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            try
            {
                return Ok(await _alunoService.GetAlunos(skip, take));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar Alunos!");
            }
        }

        [HttpGet("/oneSignal")]
        public async Task<ActionResult<IEnumerable<TbAluno>>> GetAlunosOneSignal()
        {
            try
            {
                return Ok(await _alunoService.GetAlunosOneSignal());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar Alunos!");
            }
        }

        [HttpGet("atividades/{id:int}")]
        public async Task<ActionResult<IEnumerable<AluAtividade>>> GetAlunosAtividade(int id)
        {
            try
            {
                return Ok(await _alunoService.GetAtividadesAluno(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar Alunos!");
            }
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<IAsyncEnumerable<TbAluno>>> GetAlunoByNome(string nome)
        {
            try
            {
                var alunos = await _alunoService.GetAlunoByNome(nome);
                return alunos == null ? NotFound($"Não foi possível encontrar nenhum aluno com o nome {nome}") : Ok(alunos);
            }
            catch
            {
                return BadRequest("Parâmetro Inválido!");
            }
        }

        [HttpGet("{id:int}", Name ="GetAluno")]
        public async Task<ActionResult<TbAluno>> GetAlunoById(int id)
        {
            try
            {
                var aluno = await _alunoService.GetAlunoById(id);
                return aluno == null ? NotFound($"Parâmetro id {id} não retornou resultados!") : Ok(aluno);

            }
            catch
            {
                return BadRequest("Parâmetro Inválido!");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAluno(TbAluno aluno)
        {
            try
            {
                await _alunoService.AddAluno(aluno);
                //return CreatedAtRoute(nameof(GetAluno), new { id = aluno.AluId }, aluno);
                return Ok("Aluno Adicionado com Sucesso !");
            }
            catch
            {
                return BadRequest("Parâmetro Inválido!");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateAluno(int id, [FromBody] TbAluno aluno)
        {
            try
            {
                if (aluno.AluCodigo == id)
                {
                    await _alunoService.UpdateAluno(aluno);
                    return Ok($"O Aluno de id {id} foi atualizado com sucesso!");
                }
                return BadRequest($"Dados Inconsistentes!, o id {id} deve ser o mesmo do aluno {aluno.AluId}.");
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAluno(int id)
        {
            try
            {
                var deleteAluno = await _alunoService.GetAlunoById(id);
                if (deleteAluno == null)
                    return NotFound($"Não foi possível encontrar um aluno com o id {id}");

                await _alunoService.DeleteAluno(deleteAluno);
                return Ok($"O Aluno de id {id} foi deletado com sucesso!");
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }
    }
}
