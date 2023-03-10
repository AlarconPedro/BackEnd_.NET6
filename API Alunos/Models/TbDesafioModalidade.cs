using System;
using System.Collections.Generic;

namespace API_Alunos.Models;

public partial class TbDesafioModalidade
{
    public int DesModCodigo { get; set; }

    public int? DesCodigo { get; set; }

    public int? ModCodigo { get; set; }

    public virtual TbDesafio? DesCodigoNavigation { get; set; }

    public virtual TbModalidade? ModCodigoNavigation { get; set; }
}
