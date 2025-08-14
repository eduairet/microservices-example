using System.ComponentModel.DataAnnotations;

namespace AsciiService.Models.Artwork;

public class ArtworkUpsertDto
{
    [Required] [MaxLength(100)] public string Title { get; set; } = string.Empty;
    [Required] [MaxLength(2000)] public string Description { get; set; } = string.Empty;

    [Required]
    public List<Entities.ArtworkGlyph> ArtworkGlyphs { get; set; } = [];

    public Entities.Artwork ToEntity(int? authorId, DateTime createdAt, DateTime updatedAt)
    {
        return new Entities.Artwork
        {
            Title = Title,
            Description = Description,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt,
            AuthorId = authorId,
            ArtworkGlyphs = ArtworkGlyphs
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
            ArtworkGlyphs = ArtworkGlyphs
        };
    }
}