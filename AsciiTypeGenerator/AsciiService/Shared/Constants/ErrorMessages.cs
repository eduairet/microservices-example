namespace AsciiService.Shared.Constants;

public static class ErrorMessages
{
    #region Configuration

    public static string KeyNotSet(string key) => $"Configuration key '{key}' is not set.";
    public static string EntityIdNotFound(string id) => $"Entity with id {id} not found.";

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

    public static string NoAlphabetsForUser(string userId)
        => $"No alphabets found for user ID {userId}.";

    # endregion

    #region Artworks

    public static string ArtworksNotFound(string searchText)
        => string.IsNullOrWhiteSpace(searchText)
            ? "No artworks found."
            : $"No artworks found for search text '{searchText}'.";

    public static string ArtworkNotFound(string id) => $"Artwork with ID {id} not found.";

    public static string NoArtworksForUser(string userId)
        => $"No artworks found for user ID {userId}.";

    #endregion
}