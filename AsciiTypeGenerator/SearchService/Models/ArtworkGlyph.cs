using MongoDB.Entities;

namespace SearchService.Models;

public class ArtworkGlyph : Entity
{
    public int Index { get; set; }
    public Artwork Artwork { get; set; } = new();
    public Glyph Glyph { get; set; } = new();
}