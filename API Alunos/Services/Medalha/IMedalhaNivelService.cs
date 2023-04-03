using API_Alunos.Models;

namespace API_Alunos.Services.Medalha;

public interface IMedalhaNivelService
{
    //GET
    Task<IEnumerable<TbMedalhaNivel>> GetMedalhaNiveis(int id);   
}
