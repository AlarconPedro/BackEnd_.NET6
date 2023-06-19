using API_Alunos.Context;
using API_Alunos.Models;
using API_Alunos.Models.Aluno;
using Microsoft.EntityFrameworkCore;

namespace API_Alunos.Services.Evento;

public class EventoService : IEventoService
{
    private readonly SouMaisFitContext _context;
    public EventoService(SouMaisFitContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EventoQuantidade>> GetEventos(int skip, int take) =>
        await _context.TbEventos.Skip(skip).Take(take).Select(e => new EventoQuantidade
        {
            EveCodigo = e.EveCodigo,
            EveNome = e.EveNome,
            EveDataInicio = e.EveDataInicio,
            EveDataFim = e.EveDataFim,
            EveDataInicioExibicao = e.EveDataInicioExibicao,
            EveImagem = e.EveImagem,
            EveExclusivoAluno = e.EveExclusivoAluno,
            Total = _context.TbAlunoEventos.Where(a => a.EveCodigo == e.EveCodigo).Count()
        }).ToListAsync();

    public async Task<IEnumerable<AluEvento>> GetEventoParticipantes(int id) =>
        await _context.TbAlunos.Join(_context.TbAlunoEventos, a => a.AluCodigo, ae => ae.AluCodigo, (a, ae) => new {a, ae})
            .Join(_context.TbEventos, ae => ae.ae.EveCodigo, e => e.EveCodigo, (ae, e) => new {ae, e})
            .Where(x => x.e.EveCodigo == id)
            .Select(x => new AluEvento
            {
                AluCodigo = x.ae.a.AluCodigo,
                AluNome = x.ae.a.AluNome,
                AluImagem = x.ae.a.AluImagem,
            }).ToListAsync();

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
