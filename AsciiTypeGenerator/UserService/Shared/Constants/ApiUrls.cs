namespace UserService.Shared.Constants;

public static partial class Constants
{
    public static class ApiRoutes
    {
        private const string ApiVersion = "v1";
        public const string BasePath = $"api/{ApiVersion}";
        public const string OpenApiPath = $"/openapi/{ApiVersion}.json";

        public static class Auth
        {
            public const string Register = "register";
            public const string Login = "login";
        }
    }
}