namespace AsciiService.Shared.Constants;

public static class ApiRoutes
{
    private const string _apiVersion = "v1";
    public const string BasePath = $"api/{_apiVersion}";
    public const string OpenApiPath = $"/openapi/{_apiVersion}.json";

    public static class Alphabets
    {
        public const string GetAll = "";
        public const string GetById = "{{id}}";
        public const string Create = "";
        public const string Update = "{{id}}";
        public const string Delete = "{{id}}";
        public const string UserAlphabets = "user";
    }

    public static class Artworks
    {
        public const string GetAll = "";
        public const string GetById = "{{id}}";
        public const string Create = "";
        public const string Update = "{{id}}";
        public const string Delete = "{{id}}";
        public const string UserArtworks = "user";
    }
}