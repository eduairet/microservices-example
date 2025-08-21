namespace AsciiService.Models.Glyph;

public class GlyphUpsertDto
{
    public int? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Unicode { get; set; }
    public string Drawing { get; set; } = string.Empty;

    public static Entities.Glyph ToEntity(GlyphUpsertDto glyph) => new()
    {
        Id = glyph.Id ?? 0,
        Name = glyph.Name,
        Unicode = glyph.Unicode,
        Drawing = glyph.Drawing
    };
}