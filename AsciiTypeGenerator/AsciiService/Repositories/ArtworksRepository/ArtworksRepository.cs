using AsciiService.Data;
using AsciiService.Entities;
using AsciiService.Repositories.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace AsciiService.Repositories.ArtworksRepository;

public class ArtworksRepository(AppDbContext context) : RepositoryBase<Artwork>(context), IArtworksRepository
{
    public async Task<Artwork> GetUserArtworksAsync(string userId)
    {
        if (string.IsNullOrEmpty(userId))
            throw new ArgumentNullException(nameof(userId), "User ID cannot be null or empty.");

        var artwork = await context.Artworks
            .FirstOrDefaultAsync(a => a.AuthorId == userId);

        return artwork ?? throw new KeyNotFoundException($"No artwork found for user ID: {userId}");
    }
}