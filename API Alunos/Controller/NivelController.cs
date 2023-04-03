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
        public async Task<ActionResult<IEnumerable<TbMedalhaNivel>>> GetMedalhaNiveis(int id)
    {
            try
        {
                var medalhaNiveis = await _service.GetMedalhaNiveis(id);
                return medalhaNiveis == null ? NotFound($"Não foi possível encontrar nenhuma medalha com o id {id}") : Ok(medalhaNiveis);
            }
            catch
        {
                return BadRequest("Parâmetro Inválido!");
            }
    }
}
