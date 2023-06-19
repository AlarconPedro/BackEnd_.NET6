using System;
using System.Collections.Generic;
using API_Alunos.Models.Aluno;

namespace API_Alunos.Models;

public partial class TbAlunoAtividade
{
    public long AluAtiCodigo { get; set; }

    public int? AluCodigo { get; set; }

    public double? AluAtiMedida { get; set; }

    public DateTime? AluAtiDataHora { get; set; }

    public int? AluAtiDuracaoSeg { get; set; }

    public string? AluAtiObs { get; set; }

    public int? AluAtiIntensidade { get; set; }

    public int? ModCodigo { get; set; }

    public string? AluAtiId { get; set; }

    /// <summary>
    /// Código da Atividade no Strava
    /// </summary>
    public long? AluAtiStrava { get; set; }

    /// <summary>
    /// M (Manual) ou S (Sincronizada)
    /// </summary>
    public string? AluAtiTipo { get; set; }

    public double? AluAtiVelocidade { get; set; }

    /// <summary>
    /// Ganho de Elevação
    /// </summary>
    public double? AluAtiElevacao { get; set; }

    public double? AluAtiCalorias { get; set; }

    /// <summary>
    /// Frequencia Cardíaca
    /// </summary>
    public double? AluAtiFc { get; set; }

    /// <summary>
    /// Pode ser usada tanto para corrida, caminhada e natação para cadência de braçada
    /// </summary>
    public double? AluAtiCadencia { get; set; }

    /// <summary>
    /// Medida usada na atividade de pedalada
    /// </summary>
    public double? AluAtiPotencia { get; set; }

    public string? AluAtiDescricao { get; set; }

    public string? AluAtiCidade { get; set; }

    public string? AluAtiEstado { get; set; }

    public virtual TbAluno? AluCodigoNavigation { get; set; }

    public virtual TbModalidade? ModCodigoNavigation { get; set; }

    public virtual ICollection<TbAlunoAtividadeImagem> TbAlunoAtividadeImagems { get; } = new List<TbAlunoAtividadeImagem>();
}
