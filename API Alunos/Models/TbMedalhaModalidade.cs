using System;
using System.Collections.Generic;

namespace API_Alunos.Models;

public partial class TbMedalhaModalidade
{
    public int MedModCodigo { get; set; }

    public int? MedCodigo { get; set; }

    public int? ModCodigo { get; set; }

    public virtual TbMedalha? MedCodigoNavigation { get; set; }

    public virtual TbModalidade? ModCodigoNavigation { get; set; }
}
