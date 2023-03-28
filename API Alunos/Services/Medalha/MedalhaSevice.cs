﻿using API_Alunos.Context;
using API_Alunos.Models;
using API_Alunos.Services.Medalhas;
using Microsoft.EntityFrameworkCore;

namespace API_Alunos.Services.Medalha;

public class MedalhaSevice : IMedalhaService
{
    private readonly SouMaisFitContext _context;

    public MedalhaSevice(SouMaisFitContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<TbMedalha>> GetMedalhas(int skip, int take) =>
           await _context.TbMedalhas.Skip(skip).Take(take).ToListAsync();

    public async Task<TbMedalha> GetMedalhaById(int id) =>
        await _context.TbMedalhas.FindAsync(id);

    public async Task<IEnumerable<TbMedalha>> GetMedalhaByName(string nome) =>
        await _context.TbMedalhas.Where(n => n.MedNome.Contains(nome)).ToListAsync();

    public async Task PostMedalha(TbMedalha medalha)
    {
        _context.TbMedalhas.Add(medalha);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMedalha(TbMedalha medalha)
    {
        _context.TbMedalhas.Entry(medalha).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMedalha(TbMedalha medalha)
    {
        _context.TbMedalhas.Remove(medalha);
        await _context.SaveChangesAsync();
    }
}