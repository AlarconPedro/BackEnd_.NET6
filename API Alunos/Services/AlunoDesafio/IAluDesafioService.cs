using API_Alunos.Models;

namespace API_Alunos.Services.AlunoDesafio;

public interface IAluDesafioService
{
    //GET
    Task<IEnumerable<TbAlunoDesafio>> GetAluDesafio();

    Task<IEnumerable<TbDesafio>> GetDesafioByIdAluno();
}
