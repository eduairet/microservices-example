using System.ComponentModel.DataAnnotations;
using AsciiService.Entities;

namespace AsciiService.Models.Artworks;

public class ArtworkUpsertDto
{
    [Required] [MaxLength(100)] private string Title { get; set; } = string.Empty;
    [Required] [MaxLength(2000)] private string Description { get; set; } = string.Empty;
    [Required] private List<ArtworkGlyph> Text { get; set; } = [];

    public Artwork ToEntity(int authorId, DateTime createdAt, DateTime updatedAt)
    {
        return new Artwork
        {
            Title = Title,
            Description = Description,
            Text = Text,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt,
            AuthorId = authorId
        };
    }

    public Artwork ToEntity(int id, int authorId, DateTime createdAt, DateTime updatedAt)
    {
        return new Artwork
        {
            Id = id,
            Title = Title,
            Description = Description,
            Text = Text,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt,
            AuthorId = authorId
        };
    }
}