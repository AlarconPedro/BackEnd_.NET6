using API_Alunos.Context;
using API_Alunos.Models;

namespace API_Alunos.Services.AlunoDesafio;

public class AluDesafioService : IAluDesafioService
{
    private readonly SouMaisFitContext _context;

    public AluDesafioService(SouMaisFitContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<TbAlunoDesafio>> GetAluDesafio()
    {
        throw new NotImplementedException();

    }

    public Task<IEnumerable<TbDesafio>> GetDesafioByIdAluno()
    {
        throw new NotImplementedException();
    }
}
