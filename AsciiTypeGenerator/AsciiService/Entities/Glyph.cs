using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AsciiService.Entities;

public class Glyph
{
    [Key] [MaxLength(int.MaxValue)] public string Name { get; set; } = string.Empty;
    [Required] public int Unicode { get; set; }
    [Required] public int MatrixId { get; set; }
    [ForeignKey("MatrixId")] public Matrix Matrix { get; set; } = new();
    [Required] public int AlphabetId { get; set; }
    [ForeignKey("AlphabetId")] public Alphabet Alphabet { get; set; }

    [Required]
    [MaxLength(int.MaxValue)]
    public string DrawingSerialized
    {
        get => SerializeDrawing(Drawing);
        set => Drawing = DeserializeDrawing(value);
    }

    [NotMapped] private List<List<char>> Drawing { get; set; } = [];

    private static string SerializeDrawing(List<List<char>> drawing)
    {
        return JsonConvert.SerializeObject(drawing);
    }

    private static List<List<char>> DeserializeDrawing(string serialized)
    {
        return JsonConvert.DeserializeObject<List<List<char>>>(serialized) ?? new List<List<char>>();
    }
}