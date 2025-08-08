namespace Contracts;

public class ArtworkContract
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public UserContract Author { get; set; } = new();
    public List<ArtworkGlyphContract> ArtworkGlyphs { get; set; }
}