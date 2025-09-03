using AsciiService.Entities;

namespace AsciiService.Data.SeedDataObjects;

public abstract class SeedDataArtworks
{
    public static Artwork Default(Alphabet alphabet) => new Artwork
    {
        Title = "HELLO",
        Description = "A simple hello world artwork",
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
        IsActive = true,
        ArtworkGlyphs = "HELLO".Select((c, i) => new ArtworkGlyph
        {
            Index = i,
            Glyph = alphabet.Glyphs.FirstOrDefault(g => g.Name == c.ToString())
        }).ToList()
    };
}