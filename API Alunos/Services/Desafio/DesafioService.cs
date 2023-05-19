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

    /*    public async Task<IEnumerable<TbDesafio>> GetDesafios(int skip, int take) =>
           await _context.TbDesafios.Skip(skip).Take(take).ToListAsync();
           //await _context.TbDesafios.FromSqlRaw("SELECT d.DesCodigo, COUNT(a.AluDesCodigo) AS Total FROM TbDesafio d, TbAlunoDesafio a WHERE d.DesCodigo = a.DesCodigo group by d.DesCodigo").ToListAsync();
           //await _context.TbAlunoDesafios.GroupJoin(_context.TbDesafios, a => a.DesCodigo, d => d.DesCodigo, (a, d) => new { a, d }).SelectMany(x => x.d.DefaultIfEmpty(), (a, d) => new { a, d }).GroupBy(x => x.d.DesCodigo).Select(x => new { x.Key, Total = x.Count() }).ToListAsync();
            */
    public async Task<IEnumerable<DesafioQuantidade>> GetDesafios(int skip, int take) =>
        await _context.TbDesafios.CountAsync() > 0 ? await _context.TbDesafios.Skip(skip).Take(take).Select(d => new DesafioQuantidade
        {
            DesCodigo = d.DesCodigo,
            DesNome = d.DesNome,
            DesDataInicio = d.DesDataInicio,
            DesDataFim = d.DesDataFim,
            DesImagem = d.DesImagem,
            Total = _context.TbAlunoDesafios.Where(a => a.DesCodigo == d.DesCodigo).Count()
        }).ToListAsync() : null;

    public async Task<IEnumerable<AluDesafio>> GetAlunoDesafio(int id) =>
    await _context.TbAlunos.Join(_context.TbAlunoDesafios, a => a.AluCodigo, ad => ad.AluCodigo, (a, ad) => new { a, ad })
        .Join(_context.TbDesafios, ad => ad.ad.DesCodigo, d => d.DesCodigo, (ad, d) => new { ad, d })
        .Where(x => x.d.DesCodigo == id)
        .Select(x => new AluDesafio 
        {
            AluNome = x.ad.a.AluNome,
            AluCodigo = x.ad.a.AluCodigo,
            AluImagem = x.ad.a.AluImagem,
        }).ToListAsync();

    public async Task<TbDesafio> GetDesafioById(int id) =>
        await _context.TbDesafios.Where(x => x.DesCodigo == id)
        .Select(y => new TbDesafio
        {
            DesCodigo = y.DesCodigo,
            DesNome = y.DesNome,
            DesDataInicioExibicao = y.DesDataInicioExibicao,
            DesDataFim = y.DesDataFim,
            DesDescricao = y.DesDescricao,
            DesExclusivoAluno = y.DesExclusivoAluno,
            DesMedidaDesafio = y.DesMedidaDesafio,
            DesTipoDesafio = y.DesTipoDesafio,
            DesTipoMedida = y.DesTipoMedida,
            DesDataInicio = y.DesDataInicio,
            DesImagem = y.DesImagem,
            DesId = y.DesId,
            TreCodigo = y.TreCodigo,
/*            TreCodigoNavigation = _context.TbTreinadors.Where(x => x.TreCodigo == y.TreCodigo).FirstOrDefault(),*/
/*            TbAlunoDesafios = _context.TbAlunoDesafios.Where(x => x.DesCodigo == y.DesCodigo)
                                                      .Select(xx => new TbAlunoDesafio
                                                      {
                                                          AluCodigo = xx.AluCodigo,
                                                          DesCodigo = xx.DesCodigo,
                                                          AluDesCodigo = xx.AluDesCodigo,
                                                      }).ToList(),*/
           /* TbDesafioModalidades = _context.TbDesafioModalidades.Where(x => x.DesCodigo == y.DesCodigo)
                                                                .Select(xx => new TbDesafioModalidade
                                                                {
                                                                    DesCodigo = xx.DesCodigo,
                                                                    ModCodigo = xx.ModCodigo,
                                                                    DesModCodigo = xx.DesModCodigo,
                                                                }).ToList(),*/
        }).FirstOrDefaultAsync();

    public async Task<IEnumerable<TbDesafio>> GetDesafioByNome(string nome) =>
        await _context.TbDesafios.Where(n => n.DesNome.Contains(nome)).ToListAsync();

/*    public async Task<DesafioModalidade> GetDesafioModalidadeById(int DesCodigo, int ModCodigo) =>
         await _context.TbDesafios.Join(_context.TbDesafioModalidades, d => d.DesCodigo, dm => dm.DesCodigo, (d, dm) => new { d, dm })
            .Join(_context.TbModalidades, dm => dm.dm.ModCodigo, m => m.ModCodigo, (dm, m) => new { dm, m })
            .Where(x => x.dm.d.DesCodigo == DesCodigo && x.dm.dm.ModCodigo == ModCodigo)
            .Select(x => new DesafioModalidade
            {
                ModNome = x.m.ModNome
            }).FirstOrDefaultAsync();*/
    public async Task<IEnumerable<DesafioModalidade>> GetModalidadeById(int desCodigo) =>
        await _context.TbModalidades.Join(_context.TbDesafioModalidades, m => m.ModCodigo, dm => dm.ModCodigo, (m, dm) => new { m, dm })
            .Join(_context.TbDesafios, dm => dm.dm.DesCodigo, d => d.DesCodigo, (dm, d) => new { dm, d })
            .Where(x => x.d.DesCodigo == desCodigo)
            .Select(x => new DesafioModalidade
            {
                ModNome = x.dm.m.ModNome
            }).ToListAsync();


    public async Task AddDesafio(TbDesafio desafio)
    {
        _context.TbDesafios.Add(desafio);
        await _context.SaveChangesAsync();
    }

    public async Task AddAlunoDesafio(TbAlunoDesafio alunoDesafio)
    {
        _context.TbAlunoDesafios.Add(alunoDesafio);
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
