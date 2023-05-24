using API_Alunos.Context;
using API_Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Alunos.Services.Modalidades;

public class ModalidadeService : IModalidadeSevice
{
    private readonly SouMaisFitContext _context;

    public ModalidadeService(SouMaisFitContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Modalidade>> GetModalidades(int skip, int take) => 
        await _context.TbModalidades.Skip(skip).Take(take).Select(m => new Modalidade
        {
            ModCodigo = m.ModCodigo,
            ModNome = m.ModNome,
            ModImagem = m.ModImagem,
            Total = _context.TbModalidades.Count()
        }).ToListAsync();

    public async Task<TbModalidade> GetModalidadeById(int id) => 
        await _context.TbModalidades.FindAsync(id);

    public async Task<IEnumerable<TbModalidade>> GetModalidadesByName(string nome) =>
        await _context.TbModalidades.Where(n => n.ModNome.Contains(nome)).ToListAsync();

    public async Task PostModalidade(TbModalidade modalidade)
    {
        _context.TbModalidades.Add(modalidade);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateModalidade(TbModalidade modalidade)
    {
        _context.TbModalidades.Entry(modalidade).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteModalidade(TbModalidade modalidade)
    {
        _context.TbModalidades.Remove(modalidade);
        await _context.SaveChangesAsync();
    }
}
