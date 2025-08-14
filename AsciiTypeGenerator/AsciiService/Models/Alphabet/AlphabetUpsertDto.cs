using System.ComponentModel.DataAnnotations;

namespace AsciiService.Models.Alphabet;

public class AlphabetUpsertDto
{
    [Required] [MaxLength(100)] public string Title { get; set; } = string.Empty;
    [Required] [MaxLength(2000)] public string Description { get; set; } = string.Empty;
    public List<Entities.Glyph> Glyphs { get; set; } = [];

    public Entities.Alphabet ToEntity(int? authorId, DateTime createdAt, DateTime updatedAt)
    {
        return new Entities.Alphabet
        {
            Title = Title,
            Description = Description,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt,
            AuthorId = authorId,
            Glyphs = Glyphs
        };
    }

    public Entities.Alphabet ToEntity(int id, int? authorId, DateTime createdAt, DateTime updatedAt)
    {
        return new Entities.Alphabet
        {
            Id = id,
            Title = Title,
            Description = Description,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt,
            AuthorId = authorId,
            Glyphs = Glyphs
        };
    }
}