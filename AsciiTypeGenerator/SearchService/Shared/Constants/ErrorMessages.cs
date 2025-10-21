namespace SearchService.Shared.Constants;

public static class ErrorMessages
{
    #region Configuration

    public static string KeyNotSet(string key) => $"Configuration key '{key}' is not set.";
    public const string InvalidConfiguration = "Invalid configuration.";

    #endregion

    #region Data Annotations

    public const string PositivePageNumber = "Page must be a positive integer.";

    #endregion
}