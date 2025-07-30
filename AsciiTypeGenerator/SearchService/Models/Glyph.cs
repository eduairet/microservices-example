using MongoDB.Entities;

namespace SearchService.Models;

public class Glyph : Entity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Unicode { get; set; }
    public int MatrixId { get; set; }
    public int AlphabetId { get; set; }
    public string DrawingSerialized { get; set; } = string.Empty;
}