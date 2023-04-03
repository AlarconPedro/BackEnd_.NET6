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
    public async Task<IEnumerable<TbMedalhaNivel>> GetMedalhaNiveis(int id) =>
        await _context.TbMedalhaNivels.Where(n => n.MedCodigo == id).ToListAsync();
}
