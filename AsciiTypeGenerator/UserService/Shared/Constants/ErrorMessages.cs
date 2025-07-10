namespace UserService.Shared.Constants;

public static partial class Constants
{
    public static class ErrorMessages
    {
        #region Configuration

        public static string KeyNotSet(string key) => $"Configuration key '{key}' is not set.";

        #endregion

        #region JWT

        public static string InvalidJwtUser(string user) => $"{user} is not valid";

        #endregion

        #region API

        public const string EmptyUserRegistration = "User registration data cannot be empty.";
        public const string InvalidCredentials = "Invalid username or password.";
        public const string EmptyUserLogin = "User login data cannot be empty.";
        public const string UserAlreadyExists = "User with this email already exists.";
        public const string UserNotFound = "User not found.";
        public const string UserRoleNotFound = "User role not found.";

        #endregion
    }
}