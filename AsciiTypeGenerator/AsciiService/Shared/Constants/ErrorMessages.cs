namespace AsciiService.Shared.Constants;

public static partial class Constants
{
    public static class ErrorMessages
    {
        #region Configuration

        public static string KeyNotSet(string key) => $"Configuration key '{key}' is not set.";
        public static string EntityIdNotFound(string id) => $"Entity with id {id} not found.";

        #endregion
    }
}