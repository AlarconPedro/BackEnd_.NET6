using API_Alunos.Models;
using API_Alunos.Services.Medalhas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Alunos.Controller;

[Route("api/[controller]")]
[ApiController]
public class MedalhaController : ControllerBase
{
    private IMedalhaService _service;

    public MedalhaController(IMedalhaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TbMedalha>>> GetMedalhas([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        try
        {
            return Ok(await _service.GetMedalhas(skip, take));
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar Medalhas!");
        }
    }

    [HttpGet("{nome}")]
    public async Task<ActionResult<IEnumerable<TbMedalha>>> GetMedalhasByName(string nome)
    {
        try
        {
            var medalhas =  await _service.GetMedalhaByName(nome);
            return medalhas == null ? NotFound($"Não foi possível encontrar nenhuma medalha com o nome {nome}") : Ok(medalhas);

        }
        catch
        {
            return BadRequest("Parâmetro Inválido!");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TbMedalha>> GetMedalhaByName(int id)
    {
        try
        {
            var medalha = await _service.GetMedalhaById(id);
            return medalha == null ? NotFound($"Não foi possível encontrar nenhuma medalha com o id {id}") : Ok(medalha);
        }
        catch
        {
            return BadRequest("Parâmetro Inválido!");
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddMedalha(TbMedalha medalha)
    {
        try
        {
            await _service.PostMedalha(medalha);
            return Ok("Medalha Adicionada com sucesso !");
        }
        catch
        {
            return BadRequest("Parâmetro Inválido!");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateMedalha(int id, [FromBody] TbMedalha medalha)
    {
        try
        {
            if (id == medalha.MedCodigo)
            {
                await _service.UpdateMedalha(medalha);
                return Ok($"A Medalha de id {id} foi atualizada com sucesso!");
            }
            return BadRequest($"Dados Inconsistentes!, o id {id} deve ser o mesmo da Medalha {medalha.MedCodigo}.");
        }
        catch
        {
            return BadRequest("Request Inválido");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteMedalha(int id)
    {
        try
        {
            var medalhaDelete = await _service.GetMedalhaById(id);
            if (medalhaDelete == null)
               return NotFound($"Não foi possível encontrar uma Medalha com o id {id}");

            await _service.DeleteMedalha(medalhaDelete);
            return Ok($"A Medalha de id {id} foi deletada com sucesso!");
        }
        catch
        {
            return BadRequest("Request Inválido");
        }
    }
}
