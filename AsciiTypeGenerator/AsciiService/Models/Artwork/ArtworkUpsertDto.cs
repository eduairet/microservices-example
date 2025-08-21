using System.ComponentModel.DataAnnotations;

namespace AsciiService.Models.Artwork;

public class ArtworkUpsertDto
{
    [Required] [MaxLength(100)] public string Title { get; set; } = string.Empty;
    [Required] [MaxLength(2000)] public string Description { get; set; } = string.Empty;

    [Required]
    public List<int> ArtworkGlyphsIds { get; set; } = [];

    public Entities.Artwork ToEntity(string authorId, DateTime createdAt, DateTime updatedAt)
    {
        return new Entities.Artwork
        {
            Title = Title,
            Description = Description,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt,
            AuthorId = authorId,
            ArtworkGlyphs = ArtworkGlyphsIds.Select((glyphId, i) => new Entities.ArtworkGlyph
            {
                Index = i,
                GlyphId = glyphId
            }).ToList()
        };
    }

    public Entities.Artwork ToEntity(int id, string authorId, DateTime createdAt, DateTime updatedAt)
        => new Entities.Artwork
        {
            Id = id,
            Title = Title,
            Description = Description,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt,
            AuthorId = authorId,
            ArtworkGlyphs = ArtworkGlyphsIds.Select((glyphId, i) => new Entities.ArtworkGlyph
            {
                Index = i,
                GlyphId = glyphId
            }).ToList()
        };
}