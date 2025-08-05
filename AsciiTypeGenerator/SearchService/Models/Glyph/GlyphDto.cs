namespace SearchService.Models.Glyph;

public class GlyphDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Unicode { get; set; }
    public int AlphabetId { get; set; }
    public string Drawing { get; set; } = string.Empty;
}

public static class GlyphDtoEx
{
    public static Entities.Glyph ToEntity(GlyphDto dto) => new()
    {
        ID = dto.Id.ToString(),
        Name = dto.Name,
        Unicode = dto.Unicode,
        Alphabet = new Entities.Alphabet { ID = dto.AlphabetId.ToString() },
        Drawing = dto.Drawing
    };
}