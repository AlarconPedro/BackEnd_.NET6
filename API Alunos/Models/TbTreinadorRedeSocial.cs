using System;
using System.Collections.Generic;

namespace API_Alunos.Models;

public partial class TbTreinadorRedeSocial
{
    public int TreRedCodigo { get; set; }

    public int? TreCodigo { get; set; }

    public int? TreRedTipo { get; set; }

    public string? TreRedLink { get; set; }

    public virtual TbTreinador? TreCodigoNavigation { get; set; }
}
