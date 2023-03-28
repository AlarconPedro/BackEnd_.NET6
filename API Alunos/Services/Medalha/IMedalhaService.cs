﻿using API_Alunos.Models;

namespace API_Alunos.Services.Medalhas;

public interface IMedalhaService
{
    //GET
    Task<IEnumerable<TbMedalha>> GetMedalhas(int skip, int take);
    Task<IEnumerable<TbMedalha>> GetMedalhaByName(string nome);
    Task<TbMedalha> GetMedalhaById(int id);
    //POST
    Task PostMedalha(TbMedalha medalha);
    //UPDATE
    Task UpdateMedalha(TbMedalha medalha);
    //DELETE
    Task DeleteMedalha(TbMedalha medalha);
}