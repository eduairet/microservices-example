namespace UserService.Shared.Constants;

public static partial class Constants
{
    public static class Jwt
    {
        public const string JwtKeyKey = "JWT_KEY";
        public const string JwtIssuerKey = "JWT_ISSUER";
        public const string JwtAudienceKey = "JWT_AUDIENCE";
        public const int TokenExpirationMinutes = 60;
    }
}