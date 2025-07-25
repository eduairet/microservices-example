using MongoDB.Entities;

namespace SearchService.Models;

public class Matrix : Entity
{
    public string Name { get; set; } = string.Empty;
    public int Depth { get; set; }
}