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
    public User Author { get; set; }
    public List<ArtworkGlyphDetailsDto> ArtworkGlyphs { get; set; } = [];

    public static ArtworkDetailsDto FromEntity(Entities.Artwork artwork) => new()
    {
        Id = artwork.Id,
        Title = artwork.Title,
        Description = artwork.Description,
        CreatedAt = artwork.CreatedAt,
        UpdatedAt = artwork.UpdatedAt,
        Author = artwork.Author,
        ArtworkGlyphs = artwork.ArtworkGlyphs.Select(ArtworkGlyphDetailsDto.FromEntity).ToList()
    };


    public static ArtworkUpserted ToContractUpsert(Entities.Artwork artwork) => new()
    {
        Id = artwork.Id,
        Title = artwork.Title,
        Description = artwork.Description,
        CreatedAt = artwork.CreatedAt,
        UpdatedAt = artwork.UpdatedAt,
        Author = artwork.Author is not null
            ? new UserContract
            {
                Id = artwork.Author.Id,
                UserName = artwork.Author?.UserName
            }
            : null,
        ArtworkGlyphs = artwork.ArtworkGlyphs.Select(ArtworkGlyphDetailsDto.ToContract).ToList()
    };
}