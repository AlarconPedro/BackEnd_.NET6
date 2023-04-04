using API_Alunos.Context;
using API_Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Alunos.Services.Medalha;

public class MedalhaNivelService : IMedalhaNivelService
{
    private readonly SouMaisFitContext _context;

    public MedalhaNivelService(SouMaisFitContext context)
    {
        _context = context;
    }

    //GET
    public async Task<IEnumerable<TbMedalhaNivel>> GetMedalhasNiveis(int id)
    {
        var result = await _context.TbMedalhaNivels.Where(n => n.MedCodigo == id).ToListAsync();
        return result.OrderBy(n => n.MedNivMinimo);
    }
    public async Task<TbMedalhaNivel> GetMedalhaNivel(int id) =>
        await _context.TbMedalhaNivels.FindAsync(id);

    //POST
    public async Task PostMedalhaNivel(TbMedalhaNivel medalhaNivel)
    {
        _context.Add(medalhaNivel);
        await _context.SaveChangesAsync();
    }

    //UPDATE
    public async Task UpdateMedalhaNivel(TbMedalhaNivel medalhaNivel)
    {
        _context.Entry(medalhaNivel).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    //DELETE
    public async Task DeleteMedalhaNivel(TbMedalhaNivel medalhaNivel)
    {
        _context.TbMedalhaNivels.Remove(medalhaNivel);
        await _context.SaveChangesAsync();
    }
}
