namespace Contracts;

public abstract class ArtworkGlyphContract
{
    public int Index { get; set; }
    public ArtworkContract Artwork { get; set; }
    public GlyphContract Glyph { get; set; }
}