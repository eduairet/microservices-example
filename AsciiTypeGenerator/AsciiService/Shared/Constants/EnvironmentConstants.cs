namespace AsciiService.Shared.Constants;

public class EnvironmentConstants(IConfiguration configuration)
{
    #region Database Settings

    public string ConnectionString => configuration.GetConnectionString("DefaultConnection")
                                      ?? throw new NullReferenceException(
                                          Messages.Messages.Error.KeyNotSet("DefaultConnection"));

    public string IdentityServiceUrl => configuration.GetConnectionString("IDENTITY_SERVICE_URL")
                                        ?? throw new NullReferenceException(
                                            Messages.Messages.Error.KeyNotSet("IDENTITY_SERVICE_URL"));

    #endregion
}