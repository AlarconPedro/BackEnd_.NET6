using API_Alunos.Models;

namespace API_Alunos.Services.Modalidades;

public interface IModalidadeSevice
{
    //GET
    Task<IEnumerable<Modalidade>> GetModalidades(int skip, int take);
    Task<IEnumerable<TbModalidade>> GetModalidadesByName(string nome);
    Task<TbModalidade> GetModalidadeById(int id);
    //POST
    Task PostModalidade(TbModalidade modalidade);
    //UPDATE
    Task UpdateModalidade(TbModalidade modalidade);
    //DELETE
    Task DeleteModalidade(TbModalidade modalidade);
}
