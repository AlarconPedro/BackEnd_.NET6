using API_Alunos.Models;

namespace API_Alunos.Services.Login;

public interface ILoginService
{
    Task<TbTreinador> Logar(string nome, string senha);
}
