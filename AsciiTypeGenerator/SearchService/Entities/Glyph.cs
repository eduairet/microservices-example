using MongoDB.Entities;

namespace SearchService.Entities;

public class Glyph : Entity
{
    public string Name { get; set; } = string.Empty;
    public int Unicode { get; set; }
    public string Drawing { get; set; } = string.Empty;
}