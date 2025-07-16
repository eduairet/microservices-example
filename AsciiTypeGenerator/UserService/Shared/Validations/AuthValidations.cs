namespace UserService.Shared.Validations;

public static class AuthValidations
{
    public const string UserNamePattern = @"^[a-zA-Z\d]+$";
    public const string UserNameErrorMessage = "Username can only contain letters and digits.";
    public const string PasswordPattern = @"^[a-zA-Z\d\W_]+$";
    public const string PasswordErrorMessage = "Password can contain letters, digits, and special characters.";
    public const string ConfirmPasswordErrorMessage = "Passwords do not match.";
}