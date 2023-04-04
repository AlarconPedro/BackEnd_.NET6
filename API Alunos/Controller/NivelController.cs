using API_Alunos.Models;
using API_Alunos.Services.Medalha;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Alunos.Controller;

[Route("api/[controller]")]
[ApiController]
public class NivelController : ControllerBase
{
    private IMedalhaNivelService _service;
    public NivelController(IMedalhaNivelService service)
    {
        _service = service;
    }
   
    [HttpGet("{id:int}")]
    public async Task<ActionResult<IEnumerable<TbMedalhaNivel>>> GetMedalhasNiveis(int id)
    {
        try
        {
            var medalhaNiveis = await _service.GetMedalhasNiveis(id);
            return medalhaNiveis == null ? NotFound($"Não foi possível encontrar nenhuma medalha com o id {id}") : Ok(medalhaNiveis);
        }
        catch
        {
            return BadRequest("Parâmetro Inválido!");
        }
    }

    [HttpGet("id/{id:int}")]
    public async Task<ActionResult<TbMedalhaNivel>> GetMedalhaById(int id)
    {
        try
        {
            var medalhaNiveis = await _service.GetMedalhaNivel(id);
            return medalhaNiveis == null ? NotFound($"Não foi possível encontrar nenhuma medalha com o id {id}") : Ok(medalhaNiveis);
        }
        catch
        {
            return BadRequest("Parâmetro Inválido!");
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostMedalhaNivel(TbMedalhaNivel medalhaNivel)
    {
        try
        {
            await _service.PostMedalhaNivel(medalhaNivel);
            return Ok("Medalha Adicionada com Sucesso !");
        }
        catch
        {
            return BadRequest("Parâmetro Inválido!");
        }
    }

    [HttpPut]
    public async Task<ActionResult> PutMedalhaNivel(int id, [FromBody]TbMedalhaNivel medalhaNivel)
    {
        try
        {
            if (medalhaNivel.MedCodigo == id)
            {
                await _service.UpdateMedalhaNivel(medalhaNivel);
                return Ok($"O Nível de id {id} foi atualizado com sucesso!");
            }
            return BadRequest($"Dados Inconsistentes!, o id {id} deve ser o mesmo do Nível {medalhaNivel.MedCodigo}.");
        }
        catch
        {
            return BadRequest("Parâmetro Inválido!");
        }
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteMedalhaNivel(int id)
    {
        try
        {
            var deleteMedalhaNivel = await _service.GetMedalhaNivel(id);
            if (deleteMedalhaNivel == null)
                return NotFound($"Não foi possível encontrar um Nível com o id {id}");

            await _service.DeleteMedalhaNivel(deleteMedalhaNivel);
            return Ok($"O Nível de id {id} foi deletado com sucesso!");
        }
        catch
        {
            return BadRequest("Parâmetro Inválido!");
        }
    }
}
