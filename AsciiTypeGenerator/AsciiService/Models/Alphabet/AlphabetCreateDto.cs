using System.ComponentModel.DataAnnotations;

namespace AsciiService.Models.Alphabet;

public class AlphabetCreateDto
{
    [Required] [MaxLength(100)] public string Title { get; set; } = string.Empty;
    [Required] [MaxLength(2000)] public string Description { get; set; } = string.Empty;

    public Entities.Alphabet ToEntity(int? authorId, DateTime createdAt, DateTime updatedAt) => new()
    {
        Title = Title,
        Description = Description,
        CreatedAt = createdAt,
        UpdatedAt = updatedAt,
        AuthorId = authorId,
        Glyphs = new List<Entities.Glyph>()
    };
}