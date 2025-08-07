namespace Contracts;

public abstract class GlyphContract
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Unicode { get; set; }
    public int AlphabetId { get; set; }
    public string Drawing { get; set; } = string.Empty;
    public AlphabetContract Alphabet { get; set; }
    public List<ArtworkGlyphContract> ArtworkGlyphs { get; set; } = [];
}