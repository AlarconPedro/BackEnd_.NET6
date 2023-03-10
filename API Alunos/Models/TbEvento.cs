using System;
using System.Collections.Generic;

namespace API_Alunos.Models;

public partial class TbEvento
{
    public int EveCodigo { get; set; }

    public string? EveNome { get; set; }

    public string? EveDescricao { get; set; }

    public DateTime? EveDataInicio { get; set; }

    public DateTime? EveDataFim { get; set; }

    public string? EveImagem { get; set; }

    public string? EveId { get; set; }

    public int? TreCodigo { get; set; }

    public bool? EveExclusivoAluno { get; set; }

    public DateTime? EveDataInicioExibicao { get; set; }

    public virtual ICollection<TbAlunoEvento> TbAlunoEventos { get; } = new List<TbAlunoEvento>();

    public virtual TbTreinador? TreCodigoNavigation { get; set; }
}
