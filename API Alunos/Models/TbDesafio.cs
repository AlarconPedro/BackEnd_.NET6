using System;
using System.Collections.Generic;

namespace API_Alunos.Models;

public partial class TbDesafio
{
    public int DesCodigo { get; set; }

    public string? DesNome { get; set; }

    public string? DesDescricao { get; set; }

    public DateTime? DesDataInicio { get; set; }

    public DateTime? DesDataFim { get; set; }

    public int? DesTipoDesafio { get; set; }

    public double? DesMedidaDesafio { get; set; }

    public int? TreCodigo { get; set; }

    public string? DesImagem { get; set; }

    public string? DesId { get; set; }

    public bool? DesExclusivoAluno { get; set; }

    public int? DesTipoMedida { get; set; }

    public DateTime? DesDataInicioExibicao { get; set; }

    public virtual ICollection<TbAlunoDesafio> TbAlunoDesafios { get; set; } = new List<TbAlunoDesafio>();

    public virtual ICollection<TbDesafioModalidade> TbDesafioModalidades { get; set; } = new List<TbDesafioModalidade>();

    public virtual TbTreinador? TreCodigoNavigation { get; set; }
}
