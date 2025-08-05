using MongoDB.Entities;

namespace SearchService.Entities;

public class ArtworkGlyph : Entity
{
    public int Index { get; set; }
    public Entities.Artwork Artwork { get; set; } = new();
    public Glyph Glyph { get; set; } = new();
}