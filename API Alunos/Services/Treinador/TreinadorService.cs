using API_Alunos.Context;
using API_Alunos.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace API_Alunos.Services.Treinador;

public class TreinadorService : ITreinadorService
{
    private readonly SouMaisFitContext _context;

    public TreinadorService(SouMaisFitContext context)
    {
        _context = context;
    }

    //POST
    public async Task AddTreinador(TbTreinador treinador)
    {
        string senhaEncoding = "";
        System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(treinador.TreSenha);
        byte[] hash = md5.ComputeHash(inputBytes);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        senhaEncoding = sb.ToString(); // Retorna senha criptografada 
        treinador.TreSenha = senhaEncoding;
        _context.TbTreinadors.Add(treinador);
        await _context.SaveChangesAsync();
    }

    //GET
    public async Task<IEnumerable<TbTreinador>> GetTreinadores(int skip = 0, int take = 0)
    {
        return await _context.TbTreinadors.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<TbTreinador> GetTreinadorById(int id)
    {
        return await _context.TbTreinadors.FindAsync(id);
    }

    public async Task<IEnumerable<TbTreinador>> GetTreinadorByNome(string nome)
    {
        IEnumerable<TbTreinador> treinadores;
        if (!string.IsNullOrEmpty(nome))
        {
            treinadores = await _context.TbTreinadors.Where(n => n.TreNome.Contains(nome)).ToListAsync();
        }
        else
        {
            treinadores = await GetTreinadores();
        }
        return treinadores;
    }

    //UPDATE
    public async Task UpdateTreinador(TbTreinador treinador)
    {
        string senhaEncoding = "";
        System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(treinador.TreSenha);
        byte[] hash = md5.ComputeHash(inputBytes);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        senhaEncoding = sb.ToString(); // Retorna senha criptografada 
        treinador.TreSenha = senhaEncoding;
        _context.TbTreinadors.Entry(treinador).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    //DELETE
    public async Task DeleteTreinador(TbTreinador treinador)
    {
        _context.TbTreinadors.Remove(treinador);
        await _context.SaveChangesAsync();
    }
}
