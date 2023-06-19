using API_Alunos.Models.Aluno;

namespace API_Alunos.Models;

public class AlunoDadosBasico
{
    public int? AluCodigo { get; set; }
    public string? AluNome { get; set; }
    public DateTime? AluDataNasc { get; set; }
    public string? AluImagem { get; set; }
    public string? AluFone { get; set; }
    public bool? AluAtivo { get; set; }
    public int? Total { get; set; }
}
