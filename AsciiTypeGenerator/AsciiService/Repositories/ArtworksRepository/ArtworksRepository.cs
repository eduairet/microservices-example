using AsciiService.Data;
using AsciiService.Entities;
using AsciiService.Repositories.RepositoryBase;

namespace AsciiService.Repositories.ArtworksRepository;

public class ArtworksRepository(AppDbContext context) : RepositoryBase<Artwork>(context), IArtworksRepository
{
}