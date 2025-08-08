namespace AsciiService.Shared.Constants;

public static class SuccessMessages
{
    #region Alphabets

    public static string AlphabetDeleted(int id) => $"Alphabet with ID {id} has been successfully deleted.";

    #endregion

    #region Artworks

    public static string ArtworkDeleted(int id) => $"Artwork with ID {id} has been successfully deleted.";

    #endregion
}