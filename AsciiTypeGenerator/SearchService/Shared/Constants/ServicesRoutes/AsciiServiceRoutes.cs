namespace SearchService.Shared.Constants.ServicesRoutes;

public class AsciiServiceRoutes(IConfiguration configuration)
{
    private string BaseUrl => new EnvironmentConstants(configuration).AsciiServiceUrl;
    public string GetAllAlphabets => $"{BaseUrl}/alphabets";
    public string GetAllArtworks => $"{BaseUrl}/artworks";
}