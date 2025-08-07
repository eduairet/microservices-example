namespace SearchService.Models.ArtworkGlyph;

public abstract class ArtworkGlyphDto
{
    public int Id { get; set; }
    public int Index { get; set; }
    public int ArtworkId { get; set; }
    public int GlyphId { get; set; }
}

public static class ArtworkGlyphDtoEx
{
    public static Entities.ArtworkGlyph ToEntity(ArtworkGlyphDto dto) => new()
    {
        ID = dto.Id.ToString(),
        Index = dto.Index,
        Artwork = new Entities.Artwork { ID = dto.ArtworkId.ToString() },
        Glyph = new Entities.Glyph { ID = dto.GlyphId.ToString() }
    };

    public static Entities.ArtworkGlyph ToEntity(Contracts.ArtworkGlyphContract artworkGlyph) => new()
    {
        ID = artworkGlyph.Id.ToString(),
        Index = artworkGlyph.Index,
        Artwork = new Entities.Artwork { ID = artworkGlyph.ArtworkId.ToString() },
        Glyph = new Entities.Glyph { ID = artworkGlyph.GlyphId.ToString() }
    };
}