using API_Alunos.Models;

namespace API_Alunos.Services.Treinador;

public interface ITreinadorService
{
    //GET
    Task<IEnumerable<TbTreinador>> GetTreinadores(int skip, int take);
    Task<IEnumerable<Treinadores>> GetTreinadoresCombo();
    Task<TbTreinador> GetTreinadorById(int id);
    Task<IEnumerable<TbTreinador>> GetTreinadorByNome(string nome);

    //POST
    Task AddTreinador(TbTreinador treinador);

    //UPDATE
    Task UpdateTreinador(TbTreinador treinador);

    //DELETE
    Task DeleteTreinador(TbTreinador treinador);

}
