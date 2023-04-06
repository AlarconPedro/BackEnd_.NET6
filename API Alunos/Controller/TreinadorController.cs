using API_Alunos.Models;
using API_Alunos.Services.Treinador;
using Microsoft.AspNetCore.Mvc;

namespace API_Alunos.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreinadorController : ControllerBase
    {
        private ITreinadorService _treinadorService;

        public TreinadorController(ITreinadorService treinadorService)
        {
            _treinadorService = treinadorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbTreinador>>> GetTreinadores([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            try
            {
                return Ok(await _treinadorService.GetTreinadores(skip, take));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar Treinadores!");
            }
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<IAsyncEnumerable<TbTreinador>>> GetAlunoByNome(string nome)
        {
            try
            {
                var treinador = await _treinadorService.GetTreinadorByNome(nome);
                return treinador == null ? NotFound($"Não foi possível encontrar nenhum treinador com o nome {nome} !") : Ok(treinador);
            }
            catch
            {
                return BadRequest("Parâmetro Inválido!");
            }
        }

        [HttpGet("{id:int}", Name = "GetTreinador")]
        public async Task<ActionResult<TbTreinador>> GetTreinadorById(int id)
        {
            try
            {
                var treinador = await _treinadorService.GetTreinadorById(id);
                return treinador == null ? NotFound($"Não foi possível encontrar nenhum treinador com o id {id} !") : Ok(treinador);
            }
            catch
            {
                return BadRequest("Parâmetro Inválido!");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TbTreinador>> AddTreinador(TbTreinador treinador)
        {
            try
            {
                await _treinadorService.AddTreinador(treinador);
                return CreatedAtRoute(nameof(GetTreinadores), new { id = treinador.TreId }, treinador);
            }
            catch
            {
                return BadRequest("Parâmetro Inválido!");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TbTreinador>> UpdateTreinador(int id, [FromBody] TbTreinador treinador)
        {
            try
            {
                if (treinador.TreCodigo == id)
                {
                    await _treinadorService.UpdateTreinador(treinador);
                    return Ok($"O Treinador de id {id} foi atualizado com sucesso!");
                }
                return BadRequest($"Dados Inconsistentes!, o id {id} deve ser o mesmo do treinador {treinador.TreCodigo}.");
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TbTreinador>> DeleteTreinador(int id)
        {
            try
            {
                var treinadorDelete = await _treinadorService.GetTreinadorById(id);
                if (treinadorDelete == null)
                    return NotFound($"Não foi possível encontrar um treinador com o id {id}");

                await _treinadorService.DeleteTreinador(treinadorDelete);
                return Ok($"O Treinador de id {id} foi deletado com sucesso!");
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }

    }
}
