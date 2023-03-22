using API_Alunos.Models;

namespace API_Alunos.Services.Desafio;

public interface IDesafioService
{
    //GET
    Task<IEnumerable<TbDesafio>> GetDesafios(int skip, int take);
    Task<IEnumerable<TbDesafio>> GetDesafioByNome(string nome);
    Task<TbDesafio> GetDesafioById(int id);
    //POST
    Task AddDesafio(TbDesafio desafio);
    //PUT
    Task UpdateDesafio(TbDesafio desafio);
    //DELETE
    Task DeleteDesafio(TbDesafio desafio);
}
