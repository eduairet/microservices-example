namespace AsciiService.Shared.Constants;

public static class ApiRoutes
{
    private const string _apiVersion = "v1";
    public const string BasePath = $"api/{_apiVersion}";
    public const string OpenApiPath = $"/openapi/{_apiVersion}.json";

    public static class Alphabets
    {
        public const string GetAll = "";
        public const string GetById = "{id:int}";
        public const string Create = "";
        public const string Update = "{id:int}";
        public const string Delete = "{id:int}";
        public const string UserAlphabets = "user/{username:string}";
        public const string UserPrivateAlphabets = "user";
    }

    public static class Artworks
    {
        public const string GetAll = "";
        public const string GetById = "{id:int}";
        public const string Create = "";
        public const string Update = "{id:int}";
        public const string Delete = "{id:int}";
        public const string UserArtworks = "user/{username:string}";
        public const string UserPrivateArtworks = "user";
    }
}