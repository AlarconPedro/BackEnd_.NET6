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

    public async Task<IEnumerable<AluAtividade>> GetAtividadesAluno(int id, int skip = 0, int take = 10) =>
        await _context.TbModalidades
            .Join(_context.TbAlunoAtividades, m => m.ModCodigo, aa => aa.ModCodigo, (m, aa) => new {m, aa})
            .Where(x => x.aa.AluCodigo == id)
            .Skip(skip).Take(take)
            .Select(x => new AluAtividade
            {
                ModCodigo = x.m.ModCodigo,
                ModNome = x.m.ModNome,
                AluAtiDataHora = x.aa.AluAtiDataHora,
                AluAtiMedida = x.aa.AluAtiMedida,
                AluAtiDuracaoSeg = x.aa.AluAtiDuracaoSeg,
                AluAtiIntensidade = x.aa.AluAtiIntensidade,
            }).OrderByDescending(x => x.AluAtiDataHora).ToListAsync();

    public async Task<IEnumerable<AluAtividade>> GetAtividadesAlunoByNome(int id, string nome, int skip = 0, int take = 10) => 
        await _context.TbModalidades
            .Join(_context.TbAlunoAtividades, m => m.ModCodigo, aa => aa.ModCodigo, (m, aa) => new {m, aa})
            .Where(x => x.aa.AluCodigo == id && x.m.ModNome.Contains(nome))
            .Skip(skip).Take(take)
            .Select(x => new AluAtividade
            {
                ModCodigo = x.m.ModCodigo,
                ModNome = x.m.ModNome,
                AluAtiDataHora = x.aa.AluAtiDataHora,
                AluAtiMedida = x.aa.AluAtiMedida,
                AluAtiDuracaoSeg = x.aa.AluAtiDuracaoSeg,
                AluAtiIntensidade = x.aa.AluAtiIntensidade,
            }).OrderByDescending(x => x.AluAtiDataHora).ToListAsync();

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

    public async Task<IEnumerable<AluAtiImagem>> GetImagensAlunoAtividade(int id)
    {
        return await _context.TbAlunoAtividadeImagems
            .Join(_context.TbAlunoAtividades, ai => ai.AluAtiCodigo, aa => aa.AluAtiCodigo, (ai, aa) => new {ai, aa})
            .Where(x => x.aa.AluCodigo == id)
            .Select(x => new AluAtiImagem
            {
                AluAtiImgImagem = x.ai.AluAtiImgImagem,
                AluAtiImgDescricao = x.ai.AluAtiImgDescricao,
            }).ToListAsync();    
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
