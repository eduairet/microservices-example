namespace UserService.Shared.Constants;

public static partial class Constants
{
    public class Environment(IConfiguration configuration)
    {
        #region Database Settings

        public string ConnectionString => configuration.GetConnectionString("DefaultConnection")
                                          ?? throw new NullReferenceException(
                                              ErrorMessages.KeyNotSet("DefaultConnection"));

        public string SuperAdminEmail => configuration["SUPER_ADMIN_EMAIL"] ??
                                         throw new NullReferenceException(
                                             ErrorMessages.KeyNotSet("SUPER_ADMIN_EMAIL"));

        public string SuperAdminPassword => configuration["SUPER_ADMIN_PASSWORD"] ??
                                            throw new NullReferenceException(
                                                ErrorMessages.KeyNotSet("SUPER_ADMIN_PASSWORD"));

        #endregion

        #region JWT Settings

        public string JwtKey => configuration["JWT_KEY"] ??
                                throw new NullReferenceException(ErrorMessages.KeyNotSet("JWT_KEY"));

        public string JwtIssuer => configuration["JWT_ISSUER"] ??
                                   throw new NullReferenceException(ErrorMessages.KeyNotSet("JWT_ISSUER"));

        public string JwtAudience => configuration["JWT_AUDIENCE"] ??
                                     throw new NullReferenceException(ErrorMessages.KeyNotSet("JWT_AUDIENCE"));

        #endregion
    }
}