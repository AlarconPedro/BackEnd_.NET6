using API_Alunos.Models;
using API_Alunos.Models.Aluno;
using API_Alunos.Services.Evento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Alunos.Controller;

[Route("api/[controller]")]
[ApiController]
public class EventoController : ControllerBase
{
    private IEventoService _eventoService;
    public EventoController(IEventoService eventoService)
    {
        _eventoService = eventoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TbEvento>>> GetEventos([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        try
        {
            return Ok(await _eventoService.GetEventos(skip, take));
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar Eventos!"); 
        }
    }

    [HttpGet("alunos/{id:int}")]
    public async Task<ActionResult<IEnumerable<AluEvento>>> GetEventoParticipantes(int id)
    {
        try
        {
            var evento = await _eventoService.GetEventoParticipantes(id);
            return evento == null ? NotFound($"Não foi possível encontrar nenhum evento com o id {id}") : Ok(evento);
        }
        catch
        {
            return BadRequest("Parâmetro Inválido!");
        }
    }

    [HttpGet("{nome}")]
    public async Task<ActionResult<IEnumerable<TbEvento>>> GetEventosByNome(string nome)
    {
        try
        {
            var eventos = await _eventoService.GetEventsByNome(nome);
            return eventos == null ? NotFound($"Não foi possível encontrar nenhum evento com o nome {nome}") : Ok(eventos);

        }
        catch
        {
            return BadRequest("Parâmetro Inválido!");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TbEvento>> GetEventoById(int id)
    {
        try
        {
            var evento = await _eventoService.GetEventoById(id);
            return evento == null ? NotFound($"Não foi possível encontrar nenhum evento com o id {id}") : Ok(evento);
        }
        catch
        {
            return BadRequest("Parâmetro Inválido!");
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddEvento(TbEvento evento)
    {
        try
        {
            await _eventoService.AddEvento(evento);
            return Ok("Evento Adicionado com sucesso !");
            
        }
        catch
        {
            return BadRequest("Parâmetro Inválido!");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateEvento(int id, [FromBody] TbEvento evento)
    {
        try
        {
            if (id == evento.EveCodigo)
                    {
                await _eventoService.UpdateEvento(evento);
                return Ok("Evento Atualizado com sucesso !");
            }
            else
            {
                return BadRequest($"Dados Inconsistentes!, o id {id} deve ser o mesmo do evento {evento.EveCodigo}.");
            }
        }
        catch
                {
            return BadRequest("Parâmetro Inválido!");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteEvento(int id)
    {
        try
        {
            var eventoDeletar = await _eventoService.GetEventoById(id);
            if(eventoDeletar == null)
                return NotFound($"Não foi possível encontrar um evento com o id {id}");

            await _eventoService.DeleteEvento(eventoDeletar);
            return Ok($"O Evento de id {id} foi deletado com sucesso!");
        }
        catch
        {
            return BadRequest("Request Inválido");
        }
    }
}
