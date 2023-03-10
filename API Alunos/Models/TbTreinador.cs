using System;
using System.Collections.Generic;

namespace API_Alunos.Models;

public partial class TbTreinador
{
    public int TreCodigo { get; set; }

    public string? TreNome { get; set; }

    public string? TreEmail { get; set; }

    public string? TreSenha { get; set; }

    public string? TreOneSignalId { get; set; }

    public string? TreImagem { get; set; }

    public string? TreId { get; set; }

    public string? TreFone { get; set; }

    public bool? TreAtivo { get; set; }

    public string? TreBio { get; set; }

    public virtual ICollection<TbAluno> TbAlunos { get; } = new List<TbAluno>();

    public virtual ICollection<TbDesafio> TbDesafios { get; } = new List<TbDesafio>();

    public virtual ICollection<TbEvento> TbEventos { get; } = new List<TbEvento>();

    public virtual ICollection<TbTreinadorRedeSocial> TbTreinadorRedeSocials { get; } = new List<TbTreinadorRedeSocial>();
}
