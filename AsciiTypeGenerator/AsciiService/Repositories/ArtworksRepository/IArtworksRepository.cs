using AsciiService.Entities;
using AsciiService.Repositories.RepositoryBase;

namespace AsciiService.Repositories.ArtworksRepository;

public interface IArtworksRepository : IRepositoryBase<Artwork>
{
    Task<Artwork> GetUserArtworksAsync(int userId);
}