using API_Alunos.Models;
using API_Alunos.Services.Modalidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Alunos.Controller;

[Route("api/[controller]")]
[ApiController]
public class ModalidadeController : ControllerBase
{
    private IModalidadeSevice _service;

    public ModalidadeController(IModalidadeSevice service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TbModalidade>>> GetModalidades([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        try
        {
            return Ok(await _service.GetModalidades(skip, take));
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar Modalidades!");
        }
    }

    [HttpGet("{nome}")]
    public async Task<ActionResult<IEnumerable<TbModalidade>>> GetModalidadeByNome(string nome)
    {
        try
        {
            var modalidades = await _service.GetModalidadesByName(nome);
            return modalidades == null ? NotFound($"Não foi possível encontrar nenhuma modalidade com o nome {nome}") : Ok(modalidades);
        }
        catch
        {
            return BadRequest("Parâmetro Inválido!");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TbModalidade>> GetModalidadeById(int id)
    {
        try
        {
            var modalidade = await _service.GetModalidadeById(id);
            return modalidade == null ? NotFound($"Parâmetro id {id} não retornou resultados!") : Ok(modalidade);
        }
        catch
        {
            return BadRequest("Parâmetro Inválido!");
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostModalidade(TbModalidade modalidade)
    {
        try
        {
            await _service.PostModalidade(modalidade);
            return Ok("Modalidade adicionada com Sucesso!");
        }
        catch
        {
            return BadRequest("Erro ao cadastrar Modalidade!");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateModalidade(int id, [FromBody] TbModalidade modalidade)
    {
        try
        {   
            if(id == modalidade.ModCodigo)
            {
                await _service.UpdateModalidade(modalidade);
                return Ok($"A Modalidade de id {id} foi atualizada com sucesso!");
            }
            return BadRequest($"Dados Inconsistentes!, o id {id} deve ser o mesmo da modalidade {modalidade.ModCodigo}.");
        }
        catch
        {
            return BadRequest("Erro ao atualizar Modalidade!");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteModalidade(int id)
    {
        try
        {
            var deleteModalidade = await _service.GetModalidadeById(id);
            if (deleteModalidade == null)
                return NotFound($"Não foi possível encontrar uma modalidade com o id {id}");

            await _service.DeleteModalidade(deleteModalidade);
            return Ok($"A Modalidade de id {id} foi deletada com sucesso!");
        }
        catch
        {
            return BadRequest("Request Inválido");
        }
    }
}
