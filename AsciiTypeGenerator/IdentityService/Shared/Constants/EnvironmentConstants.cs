using IdentityService.Shared.Constants.Messages;

namespace IdentityService.Shared.Constants;

public class EnvironmentConstants(IConfiguration configuration)
{
    #region Database Settings

    public string ConnectionString => configuration.GetConnectionString("DefaultConnection")
                                      ?? throw new NullReferenceException(
                                          Messages.Messages.Error.KeyNotSet("DefaultConnection"));

    public string SuperAdminEmail => configuration["SUPER_ADMIN_EMAIL"] ??
                                     throw new NullReferenceException(
                                         Messages.Messages.Error.KeyNotSet("SUPER_ADMIN_EMAIL"));

    public string SuperAdminPassword => configuration["SUPER_ADMIN_PASSWORD"] ??
                                        throw new NullReferenceException(
                                            Messages.Messages.Error.KeyNotSet("SUPER_ADMIN_PASSWORD"));

    #endregion

    #region JWT Settings

    public string JwtKey => configuration["JWT_KEY"] ??
                            throw new NullReferenceException(Messages.Messages.Error.KeyNotSet("JWT_KEY"));

    public string JwtIssuer => configuration["JWT_ISSUER"] ??
                               throw new NullReferenceException(Messages.Messages.Error.KeyNotSet("JWT_ISSUER"));

    public string JwtAudience => configuration["JWT_AUDIENCE"] ??
                                 throw new NullReferenceException(Messages.Messages.Error.KeyNotSet("JWT_AUDIENCE"));

    #endregion
}