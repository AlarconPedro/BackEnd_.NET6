using API_Alunos.Models;
using API_Alunos.Models.Aluno;
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
                /*List<AlunoDadosBasico> listaAluno = new List<AlunoDadosBasico>();
                var retorno = await _alunoService.GetAlunos(skip, take);
                for (int i = 0; i < retorno.Count(); i++)
                {
                    if (retorno.ElementAt(i).AluImagem != null)
                    {
                        var dataBytes = System.IO.File.ReadAllBytes(retorno.ElementAt(i).AluImagem);
                        listaAluno.Add(new AlunoDadosBasico
                        {
                            AluCodigo = retorno.ElementAt(i).AluCodigo,
                            AluNome = retorno.ElementAt(i).AluNome,
                            AluDataNasc = retorno.ElementAt(i).AluDataNasc,
                            AluImagem = File(dataBytes, "image/png"),
                            AluFone = retorno.ElementAt(i).AluFone,
                            AluAtivo = retorno.ElementAt(i).AluAtivo,
                            Total = retorno.ElementAt(i).Total
                        });
                    }
                }
                return Ok(listaAluno);*/
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

        [HttpGet("atividades/alunoid/{id:int}")]
        public async Task<ActionResult<IEnumerable<AluAtividade>>> GetAlunosAtividade(int id, [FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            try
            {
                return Ok(await _alunoService.GetAtividadesAluno(id, skip, take));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar Alunos!");
            }
        }

        [HttpGet("atividades/{atividadeid:int}")]
        public async Task<ActionResult<TbAlunoAtividade>> GetAtividadeById(int atividadeid)
        {
            try
            {
                var atividade = await _alunoService.GetAtividadeById(atividadeid);
                return atividade == null ? NotFound($"Não foi possível encontrar nenhuma atividade com o id {atividadeid}") : Ok(atividade);
            }
            catch
            {
                return BadRequest("Parâmetro Inválido!");
            }
        }

        [HttpGet("atividades/alunoid/{id:int}/{nome}")]
        public async Task<ActionResult<IEnumerable<AluAtividade>>> GetAlunosAtividadeByNome(int id, string nome, [FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            try
            {
                return Ok(await _alunoService.GetAtividadesAlunoByNome(id, nome, skip, take));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar Alunos!");
            }
        }

        [HttpGet("atividades/imagens/{id:int}")]
        public async Task<ActionResult<IEnumerable<AluAtiImagem>>> GetImagensAlunoAtividade(int id)
        {
            try
            {
                return Ok(await _alunoService.GetImagensAlunoAtividade(id));
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

        [HttpPost("imagemAluno/")]
        public async Task<ActionResult> UploadImage([FromForm] UploadImagemAluno imagem)
        {
            if (imagem.AluImagem != null)
            {
                string caminho = await _alunoService.AddImagemAluno(imagem);
                //return Ok("Imagem Adicionada com Sucesso ! - " + caminho);
                return Ok(caminho);
            }
            else
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
