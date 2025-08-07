using System.ComponentModel.DataAnnotations;
using AsciiService.Entities;
using AsciiService.Models.ArtworkGlyph;

namespace AsciiService.Models.Artwork;

public abstract class ArtworkUpsertDto
{
    [Required] [MaxLength(100)] private string Title { get; set; } = string.Empty;
    [Required] [MaxLength(2000)] private string Description { get; set; } = string.Empty;

    [Required]
    protected abstract List<ArtworkGlyphDetailsDto> ArtworkGlyphs { get; set; }

    public Entities.Artwork ToEntity(int? authorId, DateTime createdAt, DateTime updatedAt)
    {
        return new Entities.Artwork
        {
            Title = Title,
            Description = Description,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt,
            AuthorId = authorId,
            ArtworkGlyphs = ArtworkGlyphs.Select(g => g.ToEntity()).ToList()
        };
    }

    public Entities.Artwork ToEntity(int id, int? authorId, DateTime createdAt, DateTime updatedAt)
    {
        return new Entities.Artwork
        {
            Id = id,
            Title = Title,
            Description = Description,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt,
            AuthorId = authorId,
            ArtworkGlyphs = ArtworkGlyphs.Select(g => g.ToEntity()).ToList()
        };
    }
}