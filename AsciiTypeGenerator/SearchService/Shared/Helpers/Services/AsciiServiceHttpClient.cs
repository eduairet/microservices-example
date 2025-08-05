using SearchService.Entities;
using SearchService.Models.Alphabet;
using SearchService.Models.Artwork;
using SearchService.Shared.Constants;
using SearchService.Shared.Constants.ServicesRoutes;

namespace SearchService.Shared.Helpers.Services;

public class AsciiServiceHttpClient(HttpClient httpClient, IConfiguration configuration)
{
    private readonly string _asciiServiceUrl = new EnvironmentConstants(configuration).AsciiServiceUrl;

    public async Task<List<Alphabet>> GetAlphabetsForSearchDb()
    {
        var endpoint = $"{_asciiServiceUrl}/{AsciiServiceRoutes.GetAllAlphabets}";
        var alphabets = await httpClient.GetFromJsonAsync<List<AlphabetDto>>(endpoint);
        return alphabets is null ? [] : alphabets.Select(AlphabetDtoEx.ToEntity).ToList();
    }

    public async Task<List<Artwork>> GetArtworksForSearchDb()
    {
        var endpoint = $"{_asciiServiceUrl}/{AsciiServiceRoutes.GetAllArtworks}";
        var artworks = await httpClient.GetFromJsonAsync<List<ArtworkDto>>(endpoint);
        return artworks is null ? [] : artworks.Select(ArtworkDtoEx.ToEntity).ToList();
    }
}