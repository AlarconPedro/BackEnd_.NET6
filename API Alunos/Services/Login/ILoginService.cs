using API_Alunos.Models;

namespace API_Alunos.Services.Login;

public interface ILoginService
{
    Task Logar(LoginSistema login);
}
