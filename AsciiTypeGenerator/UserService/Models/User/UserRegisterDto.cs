using System.ComponentModel.DataAnnotations;
using UserService.Shared.Helpers;
using UserService.Shared.Validations;

namespace UserService.Models.User;

public class UserRegisterDto
{
    [Required] [EmailAddress] public string Email { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    [RegularExpression(AuthValidations.UserNamePattern, ErrorMessage = AuthValidations.UserNameErrorMessage)]
    public string UserName { get; set; }

    [Required]
    [MinLength(6)]
    [MaxLength(100)]
    [RegularExpression(AuthValidations.PasswordPattern, ErrorMessage = AuthValidations.PasswordErrorMessage)]
    public string Password { get; set; }

    [Required]
    [MinLength(6)]
    [MaxLength(100)]
    [Compare(nameof(Password), ErrorMessage = AuthValidations.ConfirmPasswordErrorMessage)]
    [RegularExpression(AuthValidations.PasswordPattern, ErrorMessage = AuthValidations.PasswordErrorMessage)]
    public string ConfirmPassword { get; set; }

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

    public Entities.User ToUser()
    {
        var newUser = new Entities.User
        {
            Email = Email,
            UserName = UserName,
            FirstName = FirstName,
            LastName = LastName,
            PhoneNumber = PhoneNumber,
            AvatarUrl = AvatarUrl,
            RoleId = ((int)Entities.IdentityRoles.User).ToString()
        };

        newUser.PasswordHash = PasswordHelpers.Hash(newUser, Password);

        return newUser;
    }
}