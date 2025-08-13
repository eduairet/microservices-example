namespace Contracts;

public class ArtworkGlyphContract
{
    public int Index { get; set; }
    public ArtworkContract Artwork { get; set; }
    public GlyphContract Glyph { get; set; }
}