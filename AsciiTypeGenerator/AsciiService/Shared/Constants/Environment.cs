namespace AsciiService.Shared.Constants;

public static partial class Constants
{
    public class Environment(IConfiguration configuration)
    {
        #region Database Settings

        public string ConnectionString => configuration.GetConnectionString("DefaultConnection")
                                          ?? throw new NullReferenceException(
                                              ErrorMessages.KeyNotSet("DefaultConnection"));

        #endregion
    }
}