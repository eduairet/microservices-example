namespace AsciiService.Shared.Constants;

public static class ApiRoutes
{
    private const string _apiVersion = "v1";
    public const string BasePath = $"api/{_apiVersion}";
    public const string OpenApiPath = $"/openapi/{_apiVersion}.json";

    public static class Alphabets
    {
        public const string GetAll = $"{BasePath}/alphabets";
        public const string GetById = $"{BasePath}/alphabets/{{id}}";
        public const string Create = $"{BasePath}/alphabets";
        public const string Update = $"{BasePath}/alphabets/{{id}}";
        public const string Delete = $"{BasePath}/alphabets/{{id}}";
        public const string UserAlphabets = $"{BasePath}/alphabets/user";
    }

    public static class Artworks
    {
    }

    public static class Users
    {
    }
}