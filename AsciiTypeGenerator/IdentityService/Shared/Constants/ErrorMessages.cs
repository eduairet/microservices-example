namespace IdentityService.Shared.Constants;

public static class ErrorMessages
{
    #region Configuration

    public static string KeyNotSet(string key) => $"Configuration key '{key}' is not set.";

    #endregion

    #region API

    public const string EmptyUserLogin = "User login data cannot be empty.";
    public const string EmptyUserRegistration = "User registration data cannot be empty.";
    public const string InvalidCredentials = "Invalid username or password.";
    public static string InvalidUser(string user) => $"{user} is not valid";
    public const string InternalServerError = "An internal server error occurred. Please try again later.";
    public const string UserAlreadyExists = "User with this email already exists.";
    public const string UserNotFound = "User not found.";

    #endregion
}