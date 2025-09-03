namespace GatewayService.Shared.Constants.Messages;

public static partial class Messages
{
    public static partial class Error
    {
        #region Configuration

        public static string KeyNotSet(string key) => $"Configuration key '{key}' is not set.";

        #endregion
    }
}