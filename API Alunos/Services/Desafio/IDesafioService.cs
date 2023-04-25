using API_Alunos.Models;

namespace API_Alunos.Services.Desafio;

public interface IDesafioService
{
    //GET
    Task<IEnumerable<DesafioQuantidade>> GetDesafios(int skip, int take);
    Task<IEnumerable<AluDesafio>> GetAlunoDesafio(int id);
    Task<IEnumerable<TbDesafio>> GetDesafioByNome(string nome);
    Task<DesafioModalidade> GetDesafioModalidadeById(int DesCodigo, int ModCodigo);
    Task<TbDesafio> GetDesafioById(int id);
    //POST
    Task AddDesafio(TbDesafio desafio);
    //PUT
    Task UpdateDesafio(TbDesafio desafio);
    //DELETE
    Task DeleteDesafio(TbDesafio desafio);
}
