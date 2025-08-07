using AsciiService.Models.Glyph;

namespace AsciiService.Models.ArtworkGlyph;

public class ArtworkGlyphDetailsDto
{
    public int Id { get; set; }
    public int Index { get; set; }
    public GlyphDetailsDto Glyph { get; set; }

    public Entities.ArtworkGlyph ToEntity()
    {
        return new Entities.ArtworkGlyph
        {
            Id = Id,
            Index = Index,
            Glyph = Glyph.ToEntity()
        };
    }

    public static ArtworkGlyphDetailsDto FromEntity(Entities.ArtworkGlyph artworkGlyph)
    {
        return new ArtworkGlyphDetailsDto
        {
            Id = artworkGlyph.Id,
            Index = artworkGlyph.Index,
            Glyph = GlyphDetailsDto.FromEntity(artworkGlyph.Glyph)
        };
    }
}