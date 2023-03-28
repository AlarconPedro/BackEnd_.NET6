using API_Alunos.Context;
using API_Alunos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace API_Alunos.Services.Desafio;

public class DesafioService : IDesafioService
{

    private readonly SouMaisFitContext _context;

    public DesafioService(SouMaisFitContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TbDesafio>> GetDesafios(int skip, int take) =>
       //await _context.TbDesafios.Skip(skip).Take(take).ToListAsync();
       await _context.TbDesafios.FromSqlRaw("SELECT d.DesCodigo, COUNT(a.AluDesCodigo) AS Total FROM TbDesafio d, TbAlunoDesafio a WHERE d.DesCodigo = a.DesCodigo group by d.DesCodigo").ToListAsync();

    public async Task<TbDesafio> GetDesafioById(int id) =>
        await _context.TbDesafios.FindAsync(id);

    public async Task<int> GetAlunoDesafioBy(int id) =>
        await _context.TbAlunoDesafios.FromSqlRaw("SELECT AluDesCodigo FROM TbAlunoDesafio WHERE DesCodigo = {0} ", id).CountAsync();

    public async Task<IEnumerable<TbDesafio>> GetDesafioByNome(string nome) =>
        await _context.TbDesafios.Where(n => n.DesNome.Contains(nome)).ToListAsync();

    public async Task AddDesafio(TbDesafio desafio)
    {
        _context.TbDesafios.Add(desafio);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateDesafio(TbDesafio desafio)
    {
        _context.TbDesafios.Entry(desafio).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    public async Task DeleteDesafio(TbDesafio desafio)
    {
        _context.TbDesafios.Remove(desafio);
        await _context.SaveChangesAsync();
    }
}
//await _context.TbDesafios.Join(_context.TbAlunos, d => d.DesId, a => a.AluId, (d, a) => new { d, a }).CountAsync();
