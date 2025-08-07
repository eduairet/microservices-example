using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsciiService.Entities;

public sealed class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] [MaxLength(int.MaxValue)] public string UserId { get; set; } = string.Empty;
    [Required] [MaxLength(256)] public string UserName { get; set; } = string.Empty;

    [System.Text.Json.Serialization.JsonIgnore]
    public ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();

    [System.Text.Json.Serialization.JsonIgnore]
    public ICollection<Alphabet> Alphabets { get; set; } = new List<Alphabet>();
}