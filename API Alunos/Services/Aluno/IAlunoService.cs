using API_Alunos.Models;
using API_Alunos.Models.Aluno;

namespace API_Alunos.Services.Aluno;

public interface IAlunoService
{
    //GET
    Task<IEnumerable<AlunoDadosBasico>> GetAlunos(int skip, int take);
    Task<TbAluno> GetAlunoById(int id);
    Task<IEnumerable<AlunoDadosBasico>> GetAlunoByNome(string nome);
    Task<IEnumerable<TbAluno>> GetAlunosOneSignal();
    Task<IEnumerable<AluAtividade>> GetAtividadesAluno(int id, int skip, int take);
    Task<TbAlunoAtividade> GetAtividadeById(int id);
    Task<IEnumerable<AluAtividade>> GetAtividadesAlunoByNome(int id, string nome, int skip, int take);
    Task<IEnumerable<AluAtiImagem>> GetImagensAlunoAtividade(int id);

    //POST
    Task AddAluno(TbAluno aluno);
    Task<String> AddImagemAluno(UploadImagemAluno imagem);

    //PUT
    Task UpdateAluno(TbAluno aluno);

    //DELETE
    Task DeleteAluno(TbAluno aluno);
}
