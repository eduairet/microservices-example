namespace GatewayService.Shared.Constants;

public class EnvironmentConstants(IConfiguration configuration)
{

    #region Service URLs

    public string IdentityServiceUrl => configuration["IDENTITY_SERVICE_URL"] ??
                            throw new NullReferenceException(Messages.Messages.Error.KeyNotSet("IDENTITY_SERVICE_URL"));

    #endregion
}