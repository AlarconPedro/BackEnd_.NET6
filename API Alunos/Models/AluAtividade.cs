namespace API_Alunos.Models;

public class AluAtividade
{
    public int? ModCodigo { get; set; }
    public string? ModNome { get; set; }
    public DateTime? AluAtiDataHora { get; set; }
    public long? AluAtiCodigo { get; set; }
    public double? AluAtiMedida { get; set; }
    public int? AluAtiDuracaoSeg { get; set; }
    public int? AluAtiIntensidade { get; set; }
    public int? Total { get; set; }
}
