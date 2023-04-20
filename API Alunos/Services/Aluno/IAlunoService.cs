using API_Alunos.Models;

namespace API_Alunos.Services.Aluno;

public interface IAlunoService
{
    //GET
    Task<IEnumerable<TbAluno>> GetAlunos(int skip, int take);
    Task<IEnumerable<TbAluno>> GetAlunosOneSignal();
    Task<IEnumerable<AluAtividade>> GetAtividadesAluno(int id, int skip, int take);
    Task<IEnumerable<AluAtividade>> GetAtividadesAlunoByNome(int id, string nome, int skip, int take);
    Task<IEnumerable<AluAtiImagem>> GetImagensAlunoAtividade(int id);
    Task<TbAluno> GetAlunoById(int id);
    Task<IEnumerable<TbAluno>> GetAlunoByNome(string nome);

    //POST
    Task AddAluno(TbAluno aluno);

    //PUT
    Task UpdateAluno(TbAluno aluno);

    //DELETE
    Task DeleteAluno(TbAluno aluno);
}
