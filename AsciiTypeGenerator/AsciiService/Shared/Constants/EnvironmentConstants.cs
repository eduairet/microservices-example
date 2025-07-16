namespace AsciiService.Shared.Constants;

public class EnvironmentConstants(IConfiguration configuration)
{
    #region Database Settings

    public string ConnectionString => configuration.GetConnectionString("DefaultConnection")
                                      ?? throw new NullReferenceException(
                                          ErrorMessages.KeyNotSet("DefaultConnection"));

    #endregion
}