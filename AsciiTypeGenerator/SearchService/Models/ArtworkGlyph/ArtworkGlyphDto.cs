namespace SearchService.Models.ArtworkGlyph;

public class ArtworkGlyphDto
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
}