using System.ComponentModel.DataAnnotations;
using IdentityService.Shared.Validations;

namespace IdentityService.Models.User;

public class UserLoginDto
{
    [Required] [EmailAddress] public string Email { get; set; }

    [Required]
    [RegularExpression(AuthValidations.PasswordPattern, ErrorMessage = AuthValidations.PasswordErrorMessage)]
    public string Password { get; set; }
}