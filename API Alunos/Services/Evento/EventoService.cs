﻿using API_Alunos.Context;
using API_Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Alunos.Services.Evento;

public class EventoService : IEventoService
{
    private readonly SouMaisFitContext _context;
    public EventoService(SouMaisFitContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TbEvento>> GetEventos(int skip, int take) =>
        await _context.TbEventos.Skip(skip).Take(take).ToListAsync();

    public async Task<IEnumerable<TbEvento>> GetEventsByNome(string nome) =>
        await _context.TbEventos.Where(n => n.EveNome.Contains(nome)).ToListAsync();

    public async Task<TbEvento> GetEventoById(int id) => await _context.TbEventos.FindAsync(id);

    public async Task AddEvento(TbEvento evento)
    {
        _context.TbEventos.Add(evento);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEvento(TbEvento evento)
    {
        _context.TbEventos.Remove(evento);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEvento(TbEvento evento)
    {
        _context.TbEventos.Entry(evento).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}