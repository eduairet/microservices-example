using System.ComponentModel.DataAnnotations;

namespace AsciiService.Models.Alphabet;

public class AlphabetCreateDto
{
    [Required] [MaxLength(100)] public string Title { get; set; } = string.Empty;
    [Required] [MaxLength(2000)] public string Description { get; set; } = string.Empty;
    public bool? IsActive { get; set; }

    public Entities.Alphabet ToEntity(string authorId, string authorName) => new()
    {
        Title = Title,
        Description = Description,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
        AuthorId = authorId,
        AuthorName = authorName,
        IsActive = IsActive ?? false,
        Glyphs = new List<Entities.Glyph>()
    };
}