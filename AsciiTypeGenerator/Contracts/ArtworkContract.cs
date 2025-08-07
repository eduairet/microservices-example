namespace Contracts;

public abstract class ArtworkContract
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int AuthorId { get; set; }
    public UserContract Author { get; set; } = new();
    public abstract List<ArtworkGlyphContract> ArtworkGlyphs { get; set; }
}