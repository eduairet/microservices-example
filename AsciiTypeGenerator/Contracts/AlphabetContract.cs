namespace Contracts;

public abstract class AlphabetContract
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public UserContract Author { get; set; } = new();
    public abstract List<GlyphContract> Glyphs { get; set; }
}