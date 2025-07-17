namespace AsciiService.Shared.Constants;

public static class ErrorMessages
{
    #region Configuration

    public static string KeyNotSet(string key) => $"Configuration key '{key}' is not set.";
    public static string EntityIdNotFound(string id) => $"Entity with id {id} not found.";

    #endregion

    #region Data Annotations

    public const string PositivePageNumber = "Page must be a positive integer.";

    #endregion

    #region Api

    public const string InvalidRequestBody = "Invalid request body";

    #endregion

    #region Alphabets

    public static string AlphabetsNotFound(string searchText)
        => string.IsNullOrWhiteSpace(searchText)
            ? "No alphabets found."
            : $"No alphabets found for search text '{searchText}'.";

    public static string AlphabetNotFound(string id) => $"Alphabet with ID {id} not found.";

    # endregion
}