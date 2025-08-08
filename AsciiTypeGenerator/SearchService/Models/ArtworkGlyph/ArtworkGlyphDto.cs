using SearchService.Models.Glyph;

namespace SearchService.Models.ArtworkGlyph;

public class ArtworkGlyphDto
{
    public int Index { get; set; }
    public GlyphDto Glyph { get; set; }

    public static Entities.ArtworkGlyph ToEntity(ArtworkGlyphDto dto) => new()
    {
        Index = dto.Index,
        Glyph = GlyphDto.ToEntity(dto.Glyph)
    };

    public static Entities.ArtworkGlyph ToEntity(Contracts.ArtworkGlyphContract contract) => new()
    {
        Index = contract.Index,
        Glyph = GlyphDto.ToEntity(contract.Glyph)
    };
}