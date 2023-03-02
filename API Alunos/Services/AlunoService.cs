using API_Alunos.Context;
using API_Alunos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace API_Alunos.Services;

public class AlunoService : IAlunoService
{
    private readonly AppDbContext _context;

    public AlunoService(AppDbContext context)
    {
        _context = context;
    }

    //POST
    public async Task AddAluno(Aluno aluno)
    {
        _context.Alunos.Add(aluno);
        await _context.SaveChangesAsync();
    }

    //GET
    public async Task<IEnumerable<Aluno>> GetAlunos()
    {
        return await _context.Alunos.ToListAsync();
    }

    public async Task<Aluno> GetAlunoById(int id)
    {
        return await _context.Alunos.FindAsync(id);
    }

    public async Task<IEnumerable<Aluno>> GetAlunoByNome(string nome)
    {
        IEnumerable<Aluno> alunos;
        if(!string.IsNullOrEmpty(nome))
        {
            alunos = await _context.Alunos.Where(n => n.Nome.Contains(nome)).ToListAsync();
        } else
        {
            alunos = await GetAlunos();
        }
        return alunos;
    }

    //UPDATE
    public async Task UpdateAluno(Aluno aluno)
    {
        _context.Entry(aluno).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    //DELETE
    public async Task DeleteAluno(Aluno aluno)
    {
        _context.Alunos.Remove(aluno);
        await _context.SaveChangesAsync();
    }
}
