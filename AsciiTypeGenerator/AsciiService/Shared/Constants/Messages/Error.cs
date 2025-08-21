namespace AsciiService.Shared.Constants.Messages;

public static partial class Messages
{
    public static partial class Error
    {
        #region Configuration

        public static string KeyNotSet(string key) => $"Configuration key '{key}' is not set.";
        public static string EntityIdNotFound(string id) => $"Entity with id {id} not found.";
        public static string MethodNotImplemented(string methodName) => $"Method '{methodName}' is not implemented.";

        #endregion

        #region Api

        public const string InvalidRequestBody = "Invalid request body";

        #endregion

        #region Alphabets

        public static string AlphabetErrorCreating(string message)
            => $"Error creating alphabet: {message}";

        public static string AlphabetErrorUpdating(string message)
            => $"Error updating alphabet: {message}";

        public static string AlphabetErrorDeleting(string message)
            => $"Error deleting alphabet: {message}";

        public static string AlphabetNotFound(int id) => $"Alphabet with ID {id} not found.";

        public static string NoAlphabetsForUser(string userId)
            => $"No alphabets found for user ID {userId}.";

        # endregion

        #region Artworks

        public static string ArtworkErrorCreating(string message)
            => $"Error creating artwork: {message}";

        public static string ArtworkErrorUpdating(string message)
            => $"Error updating artwork: {message}";

        public static string ArtworkErrorDeleting(string message)
            => $"Error deleting artwork: {message}";

        public static string ArtworkNotFound(int id) => $"Artwork with ID {id} not found.";

        public static string NoArtworksForUser(string userId)
            => $"No artworks found for user ID {userId}.";

        #endregion
    }
}