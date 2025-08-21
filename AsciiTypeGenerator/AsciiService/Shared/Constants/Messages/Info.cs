namespace AsciiService.Shared.Constants.Messages;

public static partial class Messages
{
    public static partial class Info
    {
        #region Configuration

        public const string DatabaseAlreadySeeded = "Database already seeded. Skipping seeding.";

        public const string DatabaseAlreadyHasDefaultAlphabet =
            "Database already has default alphabet. Skipping seeding.";

        public const string DatabaseAlreadyHasArtworks = "Database already has artworks. Skipping seeding.";

        #endregion

        #region Alphabets

        public static string AlphabetDeleted(int id) => $"Alphabet with ID {id} has been successfully deleted.";

        #endregion

        #region Artworks

        public static string ArtworkDeleted(int id) => $"Artwork with ID {id} has been successfully deleted.";

        #endregion
    }
}