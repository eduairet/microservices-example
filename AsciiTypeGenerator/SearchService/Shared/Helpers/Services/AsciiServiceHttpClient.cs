using SearchService.Models;
using SearchService.Shared.Constants;
using SearchService.Shared.Constants.ServicesRoutes;

namespace SearchService.Shared.Helpers.Services;

public class AsciiServiceHttpClient(HttpClient httpClient, IConfiguration configuration)
{
    private readonly string _asciiServiceUrl = new EnvironmentConstants(configuration).AsciiServiceUrl;

    public async Task<List<Alphabet>> GetAlphabetsForSearchDb()
    {
        var endpoint = $"{_asciiServiceUrl}/{AsciiServiceRoutes.GetAllAlphabets}";
        var alphabets = await httpClient.GetFromJsonAsync<object>(endpoint);
        // TODO Solve Deserialization issue with Alphabet
        return [];
    }

    public async Task<List<Artwork>> GetArtworksForSearchDb()
    {
        var endpoint = $"{_asciiServiceUrl}/{AsciiServiceRoutes.GetAllArtworks}";
        var artworks = await httpClient.GetFromJsonAsync<object>(endpoint);
        // TODO Solve Deserialization issue with Artwork
        return [];
    }
}