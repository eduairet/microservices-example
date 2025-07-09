namespace UserService.Shared.Validations;

public static partial class Validations
{
    public static class Auth
    {
        public const string UserNamePattern = @"^[a-zA-Z\d]+$";
        public const string UserNameErrorMessage = "Username can only contain letters and digits.";
        public const string PasswordPattern = @"^[a-zA-Z\d\W_]+$";
        public const string PasswordErrorMessage = "Password can contain letters, digits, and special characters.";
    }
}