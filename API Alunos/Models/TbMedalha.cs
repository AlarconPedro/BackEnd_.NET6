using System;
using System.Collections.Generic;

namespace API_Alunos.Models;

public partial class TbMedalha
{
    public int MedCodigo { get; set; }

    public string? MedNome { get; set; }

    public int? MedTipoDesafio { get; set; }

    public virtual ICollection<TbMedalhaModalidade> TbMedalhaModalidades { get; } = new List<TbMedalhaModalidade>();

    public virtual ICollection<TbMedalhaNivel> TbMedalhaNivels { get; } = new List<TbMedalhaNivel>();
}
