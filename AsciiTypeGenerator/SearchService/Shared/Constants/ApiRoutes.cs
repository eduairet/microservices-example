namespace SearchService.Shared.Constants;

public static class ApiRoutes
{
    private const string _apiVersion = "v1";
    public const string BasePath = $"api/{_apiVersion}";
    public const string OpenApiPath = $"/openapi/{_apiVersion}.json";

    public static class Search
    {
        public const string Alphabets = "alphabets";
        public const string Artworks = "artworks";
    }
}