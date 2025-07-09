using System.ComponentModel.DataAnnotations;
using UserService.Shared.Validations;

namespace UserService.Models.User;

public class UserLogin
{
    [Required] [EmailAddress] public string Email { get; set; }

    [Required]
    [RegularExpression(Validations.Auth.PasswordPattern, ErrorMessage = Validations.Auth.PasswordErrorMessage)]
    public string Password { get; set; }
}