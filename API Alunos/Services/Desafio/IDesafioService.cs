using API_Alunos.Models;
using API_Alunos.Models.Aluno;

namespace API_Alunos.Services.Desafio;

public interface IDesafioService
{
    //GET
    Task<IEnumerable<DesafioQuantidade>> GetDesafios(int skip, int take);
    Task<IEnumerable<AluDesafio>> GetAlunoDesafio(int id);
    Task<IEnumerable<TbDesafio>> GetDesafioByNome(string nome);
    /*Task<DesafioModalidade> GetDesafioModalidadeById(int DesCodigo, int ModCodigo);*/
    Task<IEnumerable<DesafioModalidade>> GetModalidadeById(int id);
    Task<TbDesafio> GetDesafioById(int id);
    //POST
    Task AddDesafio(TbDesafio desafio);
    Task AddAlunoDesafio(TbAlunoDesafio alunoDesafio);
    //PUT
    Task UpdateDesafio(TbDesafio desafio);
    //DELETE
    Task DeleteDesafio(TbDesafio desafio);
}
