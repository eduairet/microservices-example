using AsciiService.Entities;
using AsciiService.Repositories.RepositoryBase;

namespace AsciiService.Repositories.ArtworksRepository;

public interface IArtworksRepository : IRepositoryBase<Artwork>
{
    Task<List<Artwork>> GetUserArtworksAsync(int userId);
}