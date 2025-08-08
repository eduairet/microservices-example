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

    public new async Task<Artwork> GetAsync(object id)
    {
        if (id is null) return null;
        var artwork = await context.Artworks
            .Include(a => a.Author)
            .Include(a => a.ArtworkGlyphs)
            .ThenInclude(ag => ag.Glyph)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == (int)id);

        return artwork ?? throw new KeyNotFoundException(ErrorMessages.ArtworkNotFound((int)id));
    }

    public async Task<List<Artwork>> GetUserArtworksAsync(int userId)
    {
        var artwork = await context.Artworks
            .Where(a => a.AuthorId == userId)
            .Include(a => a.Author)
            .Include(a => a.ArtworkGlyphs)
            .ThenInclude(ag => ag.Glyph)
            .AsNoTracking()
            .ToListAsync();

        return artwork;
    }
}