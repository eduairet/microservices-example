namespace AsciiService.Models.Glyph;

public class GlyphDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Unicode { get; set; }
    public string Drawing { get; set; } = string.Empty;

    public Entities.Glyph ToEntity()
    {
        return new Entities.Glyph
        {
            Id = Id,
            Name = Name,
            Unicode = Unicode,
            Drawing = Drawing
        };
    }

    public static GlyphDetailsDto FromEntity(Entities.Glyph glyph)
    {
        return new GlyphDetailsDto
        {
            Id = glyph.Id,
            Name = glyph.Name,
            Unicode = glyph.Unicode,
            Drawing = glyph.Drawing
        };
    }
}