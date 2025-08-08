using AsciiService.Entities;
using AsciiService.Models.ArtworkGlyph;

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

    public static ArtworkDetailsDto FromEntity(Entities.Artwork artwork)
    {
        return new ArtworkDetailsDto
        {
            Id = artwork.Id,
            Title = artwork.Title,
            Description = artwork.Description,
            CreatedAt = artwork.CreatedAt,
            UpdatedAt = artwork.UpdatedAt,
            Author = artwork.Author,
            ArtworkGlyphs = artwork.ArtworkGlyphs.Select(ArtworkGlyphDetailsDto.FromEntity).ToList()
        };
    }
}