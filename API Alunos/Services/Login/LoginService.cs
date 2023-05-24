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

    public async Task Logar(LoginSistema login)
    {
        string senhaEncoding = "";
        try
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(login.Senha);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            senhaEncoding = sb.ToString(); // Retorna senha criptografada 
            login.Senha = senhaEncoding;
            await _context.TbTreinadors
            .Where(x => x.TreEmail == login.Email && x.TreSenha == login.Senha)
            .Select(x => new LoginSistema
            {
                Email = x.TreEmail,
                Senha = x.TreSenha,
            }).FirstOrDefaultAsync();
        }
        catch (Exception)
        {
            senhaEncoding = ""; // Caso encontre erro retorna nulo
        }
    }
}
