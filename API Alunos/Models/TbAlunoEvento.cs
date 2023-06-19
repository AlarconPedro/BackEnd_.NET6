using System;
using System.Collections.Generic;
using API_Alunos.Models.Aluno;

namespace API_Alunos.Models;

public partial class TbAlunoEvento
{
    public int AluEveCodigo { get; set; }

    public int? AluCodigo { get; set; }

    public int? EveCodigo { get; set; }

    public int? AluEveConvidados { get; set; }

    public virtual TbAluno? AluCodigoNavigation { get; set; }

    public virtual TbEvento? EveCodigoNavigation { get; set; }
}
