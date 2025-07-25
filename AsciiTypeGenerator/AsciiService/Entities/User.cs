using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsciiService.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] [MaxLength(int.MaxValue)] public string UserId { get; set; } = string.Empty;
    [Required] [MaxLength(256)] public string UserName { get; set; } = string.Empty;
    public virtual ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();
    public virtual ICollection<Alphabet> Alphabets { get; set; } = new List<Alphabet>();
}