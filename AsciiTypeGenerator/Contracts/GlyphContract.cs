namespace Contracts;

public sealed class GlyphContract
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Unicode { get; set; }
    public int AlphabetId { get; set; }
    public string Drawing { get; set; } = string.Empty;
    public AlphabetContract Alphabet { get; set; } = new();
    public List<ArtworkGlyphContract> ArtworkGlyphs { get; set; } = [];
}