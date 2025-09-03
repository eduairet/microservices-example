using System.ComponentModel.DataAnnotations;

namespace AsciiService.Models.Artwork;

public class ArtworkUpsertDto
{
    [Required] [MaxLength(100)] public string Title { get; set; } = string.Empty;
    [Required] [MaxLength(2000)] public string Description { get; set; } = string.Empty;
    public bool? IsActive { get; set; }

    [Required]
    public List<int> ArtworkGlyphsIds { get; set; } = [];

    public Entities.Artwork ToEntity(string authorId, string authorName) =>
        new()
        {
            Title = Title,
            Description = Description,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            AuthorId = authorId,
            AuthorName = authorName,
            IsActive = IsActive ?? false,
            ArtworkGlyphs = ArtworkGlyphsIds.Select((glyphId, i) => new Entities.ArtworkGlyph
            {
                Index = i,
                GlyphId = glyphId
            }).ToList()
        };

    public Entities.Artwork ToEntity(int id, string authorId, string authorName, DateTime createdAt)
        => new()
        {
            Id = id,
            Title = Title,
            Description = Description,
            CreatedAt = createdAt,
            UpdatedAt = DateTime.UtcNow,
            AuthorId = authorId,
            AuthorName = authorName,
            IsActive = IsActive ?? false,
            ArtworkGlyphs = ArtworkGlyphsIds.Select((glyphId, i) => new Entities.ArtworkGlyph
            {
                Index = i,
                GlyphId = glyphId
            }).ToList()
        };
}