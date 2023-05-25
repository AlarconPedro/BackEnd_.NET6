using API_Alunos.Models;
using API_Alunos.Services.Login;
using Microsoft.AspNetCore.Mvc;

namespace API_Alunos.Controller;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpGet("{email}/{senha}")]
    public async Task<ActionResult<TbTreinador>> GetLogin(string email, string senha)
    {
        try
        {
            var response = await _loginService.Logar(email, senha);
            return Ok(response);
        } catch
        {
            return BadRequest();
        }
    }
}
