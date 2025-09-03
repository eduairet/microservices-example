using AsciiService.Entities;
using AsciiService.Repositories.RepositoryBase;

namespace AsciiService.Repositories.ArtworksRepository;

public interface IArtworksRepository : IRepositoryBase<Artwork>
{
    Task<List<Artwork>> GetUserArtworksAsync(string userName);
    Task<List<Artwork>> GetUserPrivateArtworksAsync(string userId);
}