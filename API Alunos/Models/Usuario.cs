using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API_Alunos.Models;

public class Usuario
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O email é obrigatório")]
    [EmailAddress(ErrorMessage = "O email é inválido")]
    [StringLength(100, ErrorMessage = "O email deve ter no máximo 50 caracteres")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória")]
    [StringLength(50, ErrorMessage = "A senha deve ter no máximo 50 caracteres")]
    [PasswordPropertyText]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string Senha { get; set; }

    [StringLength(20, ErrorMessage = "O Telefone deve ter no máximo 20 caracteres")]
    [Phone]
    public string Telefone { get; set; }
    public bool Ativo { get; set; }
}
