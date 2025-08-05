using MongoDB.Entities;

namespace SearchService.Entities;

public class Glyph : Entity
{
    public string Name { get; set; } = string.Empty;
    public int Unicode { get; set; }
    public Entities.Alphabet Alphabet { get; set; } = new();
    public string Drawing { get; set; } = string.Empty;
    public List<Entities.ArtworkGlyph> ArtworkGlyphs { get; set; } = [];
}