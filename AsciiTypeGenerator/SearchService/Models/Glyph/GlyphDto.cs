using Contracts;

namespace SearchService.Models.Glyph;

public class GlyphDto
{
    public string Name { get; set; } = string.Empty;
    public int Unicode { get; set; }
    public string Drawing { get; set; } = string.Empty;

    public static Entities.Glyph ToEntity(GlyphDto dto) => new()
    {
        Name = dto.Name,
        Unicode = dto.Unicode,
        Drawing = dto.Drawing
    };

    public static Entities.Glyph ToEntity(GlyphContract contract) => new()
    {
        Name = contract.Name,
        Unicode = contract.Unicode,
        Drawing = contract.Drawing
    };
}