using AsciiService.Data;
using AsciiService.Entities;
using AsciiService.Repositories.RepositoryBase;
using AsciiService.Shared.Constants;
using Microsoft.EntityFrameworkCore;

namespace AsciiService.Repositories.ArtworksRepository;

public class ArtworksRepository(AppDbContext context) : RepositoryBase<Artwork>(context), IArtworksRepository
{
    public new async Task<List<Artwork>> GetAllAsync()
    {
        var artworks = await context.Artworks
            .Include(a => a.Author)
            .Include(a => a.ArtworkGlyphs)
            .ThenInclude(ag => ag.Glyph)
            .AsNoTracking()
            .ToListAsync();

        return artworks;
    }

    public async Task<Artwork> GetUserArtworksAsync(int userId)
    {
        var artwork = await context.Artworks
            .FirstOrDefaultAsync(a => a.AuthorId == userId);

        return artwork ?? throw new KeyNotFoundException(ErrorMessages.NoArtworksForUser(userId.ToString()));
    }
}