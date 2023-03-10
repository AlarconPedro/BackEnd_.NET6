using System;
using System.Collections.Generic;

namespace API_Alunos.Models;

public partial class TbAlunoAtividadeImagem
{
    public long AluAtiImgCodigo { get; set; }

    public string? AluAtiImgImagem { get; set; }

    public long? AluAtiCodigo { get; set; }

    public string? AluAtiImgDescricao { get; set; }

    public virtual TbAlunoAtividade? AluAtiCodigoNavigation { get; set; }
}
