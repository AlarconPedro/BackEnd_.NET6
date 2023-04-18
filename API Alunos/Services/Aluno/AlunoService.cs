using API_Alunos.Context;
using API_Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Alunos.Services.Aluno;

public class AlunoService : IAlunoService
{
    private readonly SouMaisFitContext _context;

    public AlunoService(SouMaisFitContext context)
    {
        _context = context;
    }

    //POST
    public async Task AddAluno(TbAluno aluno)
    {
        _context.TbAlunos.Add(aluno);
        await _context.SaveChangesAsync();
    }

    //GET
    public async Task<IEnumerable<TbAluno>> GetAlunos(int skip = 0, int take = 10)
    {
        var result = await _context.TbAlunos.Skip(skip).Take(take).ToListAsync();
        return result.OrderBy(x => x.AluNome);
    }

    public async Task<IEnumerable<TbAluno>> GetAlunosOneSignal()
    {
        return await _context.TbAlunos.ToListAsync();
    }

    public async Task<IEnumerable<AluAtividade>> GetAtividadesAluno(int id) =>
        await _context.TbModalidades
            .Join(_context.TbAlunoAtividades, m => m.ModCodigo, aa => aa.ModCodigo, (m, aa) => new {m, aa})
            .Join(_context.TbAlunoAtividadeImagems, aa => aa.aa.AluAtiCodigo, ai => ai.AluAtiCodigo, (aa, ai) => new {aa, ai})
            .Where(x => x.aa.aa.AluCodigo == id)
            .Select(x => new AluAtividade
            {
                ModCodigo = x.aa.m.ModCodigo,
                ModNome = x.aa.m.ModNome,
                AluAtiDataHora = x.aa.aa.AluAtiDataHora,
                AluAtiMedida = x.aa.aa.AluAtiMedida,
                AluAtiDuracaoSeg = x.aa.aa.AluAtiDuracaoSeg,
                AluAtiIntensidade = x.aa.aa.AluAtiIntensidade,
                AluAtiImgImagem = x.ai.AluAtiImgImagem
            }).ToListAsync();

public async Task<TbAluno> GetAlunoById(int id)
    {
        return await _context.TbAlunos.FindAsync(id);
    }

    public async Task<IEnumerable<TbAluno>> GetAlunoByNome(string nome)
    {
        IEnumerable<TbAluno> alunos;
        if (!string.IsNullOrEmpty(nome))
        {
            alunos = await _context.TbAlunos.Where(n => n.AluNome.Contains(nome)).ToListAsync();
        }
        else
        {
            alunos = await GetAlunos();
        }
        return alunos.OrderBy(x => x.AluNome);
    }

    //UPDATE
    public async Task UpdateAluno(TbAluno aluno)
    {
        _context.Entry(aluno).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    //DELETE
    public async Task DeleteAluno(TbAluno aluno)
    {
        _context.TbAlunos.Remove(aluno);
        await _context.SaveChangesAsync();
    }
}
