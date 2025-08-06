namespace AsciiService.Shared.Constants;

public static class SuccessMessages
{
    #region Alphabets

    public static string AlphabetDeleted(string id) => $"Alphabet with ID {id} has been successfully deleted.";

    #endregion

    #region Artworks

    public static string ArtworkDeleted(string id) => $"Artwork with ID {id} has been successfully deleted.";

    #endregion
}