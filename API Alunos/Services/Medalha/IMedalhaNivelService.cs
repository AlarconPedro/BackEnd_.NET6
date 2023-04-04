using API_Alunos.Models;

namespace API_Alunos.Services.Medalha;

public interface IMedalhaNivelService
{
    //GET
    Task<IEnumerable<TbMedalhaNivel>> GetMedalhasNiveis(int id);
    Task<TbMedalhaNivel> GetMedalhaNivel(int id);
    //POST
    Task PostMedalhaNivel(TbMedalhaNivel medalhaNivel);
    //UPDATE
    Task UpdateMedalhaNivel(TbMedalhaNivel medalhaNivel);
    //DELETE
    Task DeleteMedalhaNivel(TbMedalhaNivel medalhaNivel);
}
