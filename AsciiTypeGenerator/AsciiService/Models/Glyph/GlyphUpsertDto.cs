namespace AsciiService.Models.Glyph;

public class GlyphUpsertDto
{
    public string Name { get; set; } = string.Empty;
    public int Unicode { get; set; }
    public string Drawing { get; set; } = string.Empty;

    public static Entities.Glyph ToEntity(GlyphUpsertDto dto) => new()
    {
        Name = dto.Name,
        Unicode = dto.Unicode,
        Drawing = dto.Drawing
    };
}