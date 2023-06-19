using System;
using System.Collections.Generic;

namespace API_Alunos.Models.Aluno;

public partial class TbAluno
{
    public int AluCodigo { get; set; }

    public string? AluNome { get; set; }

    public DateTime? AluDataNasc { get; set; }

    public string? AluEmail { get; set; }

    public string? AluSenha { get; set; }

    public int? TreCodigo { get; set; }

    public string? AluOneSignalId { get; set; }

    public string? AluImagem { get; set; }

    public string? AluId { get; set; }

    public string? AluFone { get; set; }

    public string? AluSexo { get; set; }

    public bool? AluAtivo { get; set; }

    public string? AluObs { get; set; }

    public string? AluStravaCode { get; set; }

    public virtual ICollection<TbAlunoAtividade> TbAlunoAtividades { get; } = new List<TbAlunoAtividade>();

    public virtual ICollection<TbAlunoDesafio> TbAlunoDesafios { get; } = new List<TbAlunoDesafio>();

    public virtual ICollection<TbAlunoEvento> TbAlunoEventos { get; } = new List<TbAlunoEvento>();

    public virtual TbTreinador? TreCodigoNavigation { get; set; }
}
