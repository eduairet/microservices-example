using Contracts;

namespace AsciiService.Models.Glyph;

public class GlyphDetailsDto
{
    public string Name { get; set; } = string.Empty;
    public int Unicode { get; set; }
    public string Drawing { get; set; } = string.Empty;

    public static Entities.Glyph ToEntity(GlyphDetailsDto dto) => new()
    {
        Name = dto.Name,
        Unicode = dto.Unicode,
        Drawing = dto.Drawing
    };

    public static GlyphDetailsDto FromEntity(Entities.Glyph glyph) => new()
    {
        Name = glyph.Name,
        Unicode = glyph.Unicode,
        Drawing = glyph.Drawing
    };
    
    public static GlyphContract ToContract(GlyphDetailsDto dto) => new()
    {
        Name = dto.Name,
        Unicode = dto.Unicode,
        Drawing = dto.Drawing
    };
}