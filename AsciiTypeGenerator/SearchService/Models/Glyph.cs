using MongoDB.Entities;

namespace SearchService.Models;

public class Glyph : Entity
{
    public string Name { get; set; } = string.Empty;
    public int Unicode { get; set; }
    public Alphabet Alphabet { get; set; } = new();
    public string Drawing { get; set; } = string.Empty;
    public List<ArtworkGlyph> ArtworkGlyphs { get; set; } = [];
}