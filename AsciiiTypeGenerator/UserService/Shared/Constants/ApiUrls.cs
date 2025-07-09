namespace UserService.Shared.Constants;

public static partial class Constants
{
    public static class ApiUrls
    {
        public const string ApiVersion = "v1";
        public const string BasePath = $"api/{ApiVersion}";

        public static class Auth
        {
            public const string Login = $"login";
            public const string Register = $"register";
        }
    }
}