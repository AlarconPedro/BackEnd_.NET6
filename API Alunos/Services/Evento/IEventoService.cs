﻿using API_Alunos.Models;
using API_Alunos.Models.Aluno;

namespace API_Alunos.Services.Evento;

public interface IEventoService
{
    //GET
    Task<IEnumerable<EventoQuantidade>> GetEventos(int skip, int take);
    Task<IEnumerable<TbEvento>> GetEventsByNome(string nome);
    Task<IEnumerable<AluEvento>> GetEventoParticipantes(int id);
    Task<TbEvento> GetEventoById(int id);
    //POST
    Task AddEvento(TbEvento evento);
    //UPDATE
    Task UpdateEvento(TbEvento evento);
    //DELETE
    Task DeleteEvento(TbEvento evento);
}
