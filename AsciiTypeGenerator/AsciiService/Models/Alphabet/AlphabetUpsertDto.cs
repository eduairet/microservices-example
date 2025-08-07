using System.ComponentModel.DataAnnotations;
using AsciiService.Models.Glyph;

namespace AsciiService.Models.Alphabet;

public abstract class AlphabetUpsertDto
{
    [Required] [MaxLength(100)] private string Title { get; set; } = string.Empty;
    [Required] [MaxLength(2000)] private string Description { get; set; } = string.Empty;
    protected abstract List<GlyphDetailsDto> Glyphs { get; set; }

    public Entities.Alphabet ToEntity(int authorId, DateTime createdAt, DateTime updatedAt)
    {
        return new Entities.Alphabet
        {
            Title = Title,
            Description = Description,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt,
            AuthorId = authorId,
            Glyphs = Glyphs.Select(g => g.ToEntity()).ToList()
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
            Glyphs = Glyphs.Select(g => g.ToEntity()).ToList()
        };
    }
}