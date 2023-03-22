using API_Alunos.Models;

namespace API_Alunos.Services.Aluno;

public interface IAlunoService
{
    //GET
    Task<IEnumerable<TbAluno>> GetAlunos(int skip, int take);

    Task<TbAluno> GetAlunoById(int id);

    Task<IEnumerable<TbAluno>> GetAlunoByNome(string nome);

    //POST
    Task AddAluno(TbAluno aluno);

    //PUT
    Task UpdateAluno(TbAluno aluno);

    //DELETE
    Task DeleteAluno(TbAluno aluno);
}
