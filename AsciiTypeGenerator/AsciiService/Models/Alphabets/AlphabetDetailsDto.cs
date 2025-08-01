using AsciiService.Entities;

namespace AsciiService.Models.Alphabets;

public class AlphabetDetailsDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public User Author { get; set; } = new();
    public List<Glyph> Glyphs { get; set; } = [];

    public static AlphabetDetailsDto FromEntity(Alphabet alphabet)
    {
        return new AlphabetDetailsDto
        {
            Id = alphabet.Id,
            Title = alphabet.Title,
            Description = alphabet.Description,
            CreatedAt = alphabet.CreatedAt,
            UpdatedAt = alphabet.UpdatedAt,
            Author = alphabet.Author,
            Glyphs = alphabet.Glyphs.ToList()
        };
    }
}