using System.ComponentModel.DataAnnotations;
using AsciiService.Entities;

namespace AsciiService.Models.Alphabets;

public class AlphabetUpsertDto
{
    [Required] [MaxLength(100)] private string Title { get; set; } = string.Empty;
    [Required] [MaxLength(2000)] private string Description { get; set; } = string.Empty;
    private List<Glyph> Glyphs { get; set; } = [];

    public Alphabet ToEntity(int authorId, DateTime createdAt, DateTime updatedAt)
    {
        return new Alphabet
        {
            Title = Title,
            Description = Description,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt,
            Glyphs = Glyphs,
            AuthorId = authorId
        };
    }

    public Alphabet ToEntity(int id, int? authorId, DateTime createdAt, DateTime updatedAt)
    {
        return new Alphabet
        {
            Id = id,
            Title = Title,
            Description = Description,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt,
            Glyphs = Glyphs,
            AuthorId = authorId
        };
    }
}