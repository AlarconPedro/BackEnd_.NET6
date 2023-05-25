using API_Alunos.Context;
using API_Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Alunos.Services.Login;

public class LoginService : ILoginService
{
    private readonly SouMaisFitContext _context;

    public LoginService(SouMaisFitContext context)
    {
        _context = context;
    }

    public async Task<TbTreinador> Logar(string email, string senha)
    {
        string senhaEncoding = "";
        try
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(senha);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            senhaEncoding = sb.ToString(); // Retorna senha criptografada 
            senha = senhaEncoding;
        }
        catch (Exception)
        {
            senhaEncoding = ""; // Caso encontre erro retorna nulo
        }
        return await _context.TbTreinadors
                .Where(x => x.TreEmail == email && x.TreSenha == senha)
                .FirstOrDefaultAsync();
    }
}
