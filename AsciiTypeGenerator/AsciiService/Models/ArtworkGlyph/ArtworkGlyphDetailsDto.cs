using AsciiService.Models.Glyph;
using Contracts;

namespace AsciiService.Models.ArtworkGlyph;

public class ArtworkGlyphDetailsDto
{
    public int Index { get; set; }
    public GlyphDetailsDto Glyph { get; set; }

    public static ArtworkGlyphDetailsDto FromEntity(Entities.ArtworkGlyph artworkGlyph) => new()
    {
        Index = artworkGlyph.Index,
        Glyph = GlyphDetailsDto.FromEntity(artworkGlyph.Glyph)
    };

    public static ArtworkGlyphContract ToContract(Entities.ArtworkGlyph artworkGlyph) => new()
    {
        Index = artworkGlyph.Index,
        Glyph = GlyphDetailsDto.ToContract(artworkGlyph.Glyph)
    };
}