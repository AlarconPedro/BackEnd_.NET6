using API_Alunos.Models;

namespace API_Alunos.Services;

public interface IAlunoService
{
    //GET
    Task<IEnumerable<Aluno>> GetAlunos();

    Task<Aluno> GetAlunoById(int id);

    Task<IEnumerable<Aluno>> GetAlunoByNome(string nome);

    //POST
    Task AddAluno(Aluno aluno);

    //PUT
    Task UpdateAluno(Aluno aluno);

    //DELETE
    Task DeleteAluno(Aluno aluno);
}
