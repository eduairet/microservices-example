namespace IdentityService.Shared.Constants.Messages;

public static partial class Messages
{
    public static partial class Error
    {
        #region Configuration

        public static string KeyNotSet(string key) => $"Configuration key '{key}' is not set.";

        public const string DatabaseInitializationErrorLog =
            "An error occurred during database initialization: {Message}";

        #endregion

        #region API

        public const string EmptyUserLogin = "User login data cannot be empty.";
        public const string EmptyUserRegistration = "User registration data cannot be empty.";
        public const string InvalidCredentials = "Invalid username or password.";
        public static string InvalidUser(string user) => $"{user} is not valid";
        public const string InternalServerError = "An internal server error occurred. Please try again later.";
        public const string UserAlreadyExists = "User with this email already exists.";
        public const string UserNotFound = "User not found.";

        public const string UserRegisteringErrorLog =
            "An error occurred while registering user with email: {Email}\n{Exception}";

        public const string UserLoginErrorLog =
            "An error occurred during login attempt with email: {Email}\n{Exception}";

        #endregion
    }
}