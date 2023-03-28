using API_Alunos.Models;
using API_Alunos.Services.Desafio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Alunos.Controller;

[Route("api/[controller]")]
[ApiController]
public class DesafioController : ControllerBase
{
    private IDesafioService _desafioService;
    public DesafioController(IDesafioService desafioService)
    {
        _desafioService = desafioService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TbDesafio>>> GetDesafios([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        try
        {
            return Ok(await _desafioService.GetDesafios(skip, take));
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar Desafios!");
        }
    }

    [HttpGet("{nome}")]
    public async Task<ActionResult<IAsyncEnumerable<TbDesafio>>> GetDesafioByNome(string nome)
    {
        try
        {
            var desafio = await _desafioService.GetDesafioByNome(nome);
            return desafio == null ? NotFound($"Não foi possível encontrar nenhum desafio com o nome {nome} !") : Ok(desafio);
        }
        catch
        {
            return BadRequest("Parâmetro Inválido!");
        }
    }

    /*  [HttpGet("{id:int}", Name = "GetDesafio")]
      public async Task<ActionResult<int>> GetDesafioById(int id)
      {
          try
          {
              var desafio = await _desafioService.GetAlunoDesafioBy(id);
              return desafio == null ? NotFound($"Não foi possível encontrar nenhum desafio com o id {id} !") : Ok(desafio);
          }
          catch
          {
              return BadRequest("Parâmetro Inválido!");
          }
      }*/

    [HttpGet("{id:int}", Name = "GetDesafio")]
    public async Task<ActionResult<TbDesafio>> GetDesafioById(int id)
    {
        try
        {
            var desafio = await _desafioService.GetDesafioById(id);
            return desafio == null ? NotFound($"Não foi possível encontrar nenhum desafio com o id {id} !") : Ok(desafio);
        }
        catch
        {
            return BadRequest("Parâmetro Inválido!");
        }
    }

    [HttpPost]
    public async Task<ActionResult<TbDesafio>> AddDesafio(TbDesafio desafio)
    {
        try
        {
            if (desafio == null)
                return BadRequest();

            await _desafioService.AddDesafio(desafio);
            return Ok(desafio);
            //return CreatedAtRoute(nameof(GetDesafioById), new { id = createdDesafio.IdDesafio }, createdDesafio);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar Desafio!");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<TbDesafio>> UpdateDesafio(int id, TbDesafio desafio)
    {
        try
        {
            if (id != desafio.DesCodigo)
                return BadRequest("Id do Desafio não corresponde ao informado na requisição!");

            var desafioToUpdate = await _desafioService.GetDesafioById(id);
            if (desafioToUpdate == null)
                return NotFound($"Não foi possível encontrar nenhum desafio com o id {id} !");

           await _desafioService.UpdateDesafio(desafio);
           return Ok($"O Desafio de id {id} foi atualizado com sucesso!");
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar Desafio!");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<TbDesafio>> DeleteDesafio(int id)
    {
        try
        {
            var desafioToDelete = await _desafioService.GetDesafioById(id);
            if (desafioToDelete == null)
                return NotFound($"Não foi possível encontrar nenhum desafio com o id {id} !");

            await _desafioService.DeleteDesafio(desafioToDelete);
            return Ok($"Desafio com o id {id} deletado com sucesso!");
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar Desafio!");
        }   
    }
}
