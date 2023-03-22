using API_Alunos.Models;

namespace API_Alunos.Services.Evento;

public interface IEventoService
{
    //GET
    Task<IEnumerable<TbEvento>> GetEventos(int skip, int take);
    Task<IEnumerable<TbEvento>> GetEventsByNome(string nome);
    Task<TbEvento> GetEventoById(int id);
    //POST
    Task AddEvento(TbEvento evento);
    //UPDATE
    Task UpdateEvento(TbEvento evento);
    //DELETE
    Task DeleteEvento(TbEvento evento);
}
