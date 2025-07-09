using System.ComponentModel.DataAnnotations;
using UserService.Shared.Validations;

namespace UserService.Models.User;

public class UserRegister
{
    [Required] [EmailAddress] public string Email { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    [RegularExpression(Validations.Auth.UserNamePattern, ErrorMessage = Validations.Auth.UserNameErrorMessage)]
    public string UserName { get; set; }

    [Required]
    [MinLength(6)]
    [MaxLength(100)]
    [RegularExpression(Validations.Auth.PasswordPattern, ErrorMessage = Validations.Auth.PasswordErrorMessage)]
    public string Password { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    public string LastName { get; set; }

    [Phone] public string PhoneNumber { get; set; }

    [Url] public string AvatarUrl { get; set; }
}