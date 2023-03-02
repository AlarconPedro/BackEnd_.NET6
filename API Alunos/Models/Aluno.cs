using System.ComponentModel.DataAnnotations;

namespace API_Alunos.Models;

public class Aluno
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O email é obrigatório")]
    [EmailAddress(ErrorMessage = "O email é inválido")]
    [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A idade é obrigatória")]
    [Range(1, 120, ErrorMessage = "A idade deve estar entre 1 e 120 anos")]
    public int Idade { get; set; }
}   
