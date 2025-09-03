using MongoDB.Entities;

namespace SearchService.Entities;

public class Alphabet : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public string AuthorName { get; set; }
    public List<Glyph> Glyphs { get; set; } = [];
}