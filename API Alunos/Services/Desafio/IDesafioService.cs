﻿using API_Alunos.Models;

namespace API_Alunos.Services.Desafio;

public interface IDesafioService
{
    //GET
    Task<IEnumerable<AluDesafio>> GetDesafios(int skip, int take);
    Task<IEnumerable<TbDesafio>> GetDesafioByNome(string nome);
    Task<TbDesafio> GetDesafioById(int id);
    Task<int> GetAlunoDesafioBy(int id);
    //POST
    Task AddDesafio(TbDesafio desafio);
    //PUT
    Task UpdateDesafio(TbDesafio desafio);
    //DELETE
    Task DeleteDesafio(TbDesafio desafio);
}
