using System;
using System.Collections.Generic;

namespace API_Alunos.Models;

public partial class TbModalidade
{
    public int ModCodigo { get; set; }

    public string? ModNome { get; set; }

    public string? ModImagem { get; set; }

    public string? ModId { get; set; }

    public int? ModTipoDesafio { get; set; }

    public int? ModTipoMedida { get; set; }

    public bool? ModAtiva { get; set; }

    public virtual ICollection<TbAlunoAtividade> TbAlunoAtividades { get; } = new List<TbAlunoAtividade>();

    public virtual ICollection<TbDesafioModalidade> TbDesafioModalidades { get; } = new List<TbDesafioModalidade>();

    public virtual ICollection<TbMedalhaModalidade> TbMedalhaModalidades { get; } = new List<TbMedalhaModalidade>();
}
