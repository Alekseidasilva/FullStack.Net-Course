using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Request.Account;

public class LoginRequest : Request
{
    [Required(ErrorMessage = "O Campo email e obrigatorio")]
    [EmailAddress(ErrorMessage = "Email Invalido")]
    public string Email { get; set; } = String.Empty;

    [Required(ErrorMessage = "O Campo senha e obrigatorio")]
    public string Password { get; set; } = String.Empty;
}