using MongoDB.Entities;

namespace SearchService.Models;

public class Alphabet : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public List<Glyph> Glyphs { get; set; } = [];
    public int AuthorId { get; set; }
}