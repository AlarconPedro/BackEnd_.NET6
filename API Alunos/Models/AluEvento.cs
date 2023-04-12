namespace API_Alunos.Models;

public class AluEvento
{
        public int EveCodigo { get; set; }
 
        public string? EveNome { get; set; }
 
        public DateTime? EveDataInicio { get; set; }
 
        public DateTime? EveDataFim { get; set; }
 
        public string? EveImagem { get; set; }
  
        public bool? EveExclusivoAluno { get; set; }
  
        public int? Total { get; set; }
}
