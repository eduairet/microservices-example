using AsciiService.Data;
using AsciiService.Entities;
using AsciiService.Models.Artwork;
using AsciiService.Repositories.RepositoryBase;
using Contracts;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace AsciiService.Repositories.ArtworksRepository;

public class ArtworksRepository(AppDbContext context, IPublishEndpoint publishEndpoint)
    : RepositoryBase<Artwork>(context, publishEndpoint), IArtworksRepository
{
    protected override TContract FromEntityToCreateContract<TContract>(Artwork entity) =>
        (TContract)(object)ArtworkDetailsDto.ToContractUpsert(entity);

    protected override TContract FromEntityToUpdateContract<TContract>(Artwork entity) =>
        (TContract)(object)ArtworkDetailsDto.ToContractUpsert(entity);

    protected override TContract FromEntityToDeleteContract<TContract>(Artwork entity) =>
        (TContract)(object)new ArtworkDeleted { Id = entity.Id };

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