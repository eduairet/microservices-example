namespace Contracts;

public abstract class ArtworkGlyphContract
{
    public int Id { get; set; }
    public int Index { get; set; }
    public int ArtworkId { get; set; }
    public ArtworkContract Artwork { get; set; }
    public int GlyphId { get; set; }
    public GlyphContract Glyph { get; set; }
}