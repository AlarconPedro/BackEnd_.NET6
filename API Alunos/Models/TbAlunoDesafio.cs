using System;
using System.Collections.Generic;
using API_Alunos.Models.Aluno;

namespace API_Alunos.Models;

public partial class TbAlunoDesafio
{
    public int AluDesCodigo { get; set; }

    public int? AluCodigo { get; set; }

    public int? DesCodigo { get; set; }

    public virtual TbAluno? AluCodigoNavigation { get; set; }

    public virtual TbDesafio? DesCodigoNavigation { get; set; }
}
