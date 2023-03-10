using System;
using System.Collections.Generic;

namespace API_Alunos.Models;

public partial class TbMedalhaNivel
{
    public int MedNivCodigo { get; set; }

    public int? MedCodigo { get; set; }

    public double? MedNivMinimo { get; set; }

    public string? MedNivImagem { get; set; }

    public string? MedNivId { get; set; }

    public virtual TbMedalha? MedCodigoNavigation { get; set; }
}
