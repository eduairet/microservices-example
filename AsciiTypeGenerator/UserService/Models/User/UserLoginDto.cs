using System.ComponentModel.DataAnnotations;
using UserService.Shared.Validations;

namespace UserService.Models.User;

public class UserLoginDto
{
    [Required] [EmailAddress] public string Email { get; set; }

    [Required]
    [RegularExpression(AuthValidations.PasswordPattern, ErrorMessage = AuthValidations.PasswordErrorMessage)]
    public string Password { get; set; }
}