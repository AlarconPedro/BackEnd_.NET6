﻿namespace API_Alunos.Models;

public class AluDesafio
{
    public int DesCodigo { get; set; }

    public string? DesNome { get; set; }

    public DateTime? DesDataInicio { get; set; }

    public DateTime? DesDataFim { get; set; }

    public string? DesImagem { get; set; }

    public string? DesId { get; set; }

    public int? Total { get; set; }
}