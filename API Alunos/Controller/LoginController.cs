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

    [HttpGet]
    public async Task<ActionResult> GetLogin(LoginSistema login)
    {
        try
        {
            await _loginService.Logar(login);
            return Ok();
        } catch
        {
            return BadRequest();
        }
    }
}
