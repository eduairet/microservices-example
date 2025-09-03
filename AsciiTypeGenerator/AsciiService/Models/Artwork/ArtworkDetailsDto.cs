using AsciiService.Entities;
using AsciiService.Models.ArtworkGlyph;
using Contracts;

namespace AsciiService.Models.Artwork;

public class ArtworkDetailsDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string AuthorName { get; set; }
    public List<ArtworkGlyphDetailsDto> ArtworkGlyphs { get; set; } = [];

    public static ArtworkDetailsDto FromEntity(Entities.Artwork artwork) => new()
    {
        Id = artwork.Id,
        Title = artwork.Title,
        Description = artwork.Description,
        CreatedAt = artwork.CreatedAt,
        UpdatedAt = artwork.UpdatedAt,
        AuthorName = artwork.AuthorName,
        ArtworkGlyphs = artwork.ArtworkGlyphs.Select(ArtworkGlyphDetailsDto.FromEntity).ToList()
    };


    public static ArtworkCreated ToContractCreate(Entities.Artwork artwork) => new()
    {
        Id = artwork.Id,
        Title = artwork.Title,
        Description = artwork.Description,
        CreatedAt = artwork.CreatedAt,
        UpdatedAt = artwork.UpdatedAt,
        AuthorName = artwork.AuthorName,
        ArtworkGlyphs = artwork.ArtworkGlyphs.Select(ArtworkGlyphDetailsDto.ToContract).ToList()
    };

    public static ArtworkUpdated ToContractUpdate(Entities.Artwork artwork) => new()
    {
        Id = artwork.Id,
        Title = artwork.Title,
        Description = artwork.Description,
        CreatedAt = artwork.CreatedAt,
        UpdatedAt = artwork.UpdatedAt,
        AuthorName = artwork.AuthorName,
        ArtworkGlyphs = artwork.ArtworkGlyphs.Select(ArtworkGlyphDetailsDto.ToContract).ToList()
    };
}