using System.ComponentModel.DataAnnotations;
using AsciiService.Entities;

namespace AsciiService.Models.Alphabets;

public class AlphabetDetailsDto
{
    [Required] [MaxLength(100)] public string Title { get; set; } = string.Empty;

    [Required] [MaxLength(2000)] public string Description { get; set; } = string.Empty;

    [Required] [MaxLength(int.MaxValue)] public string Characters { get; set; } = string.Empty;

    [Required] [MaxLength(int.MaxValue)] public string AuthorId { get; set; } = string.Empty;

    public static AlphabetDetailsDto FromEntity(Alphabet alphabet)
    {
        return new AlphabetDetailsDto
        {
            Title = alphabet.Title,
            Description = alphabet.Description,
            Characters = alphabet.Characters,
            AuthorId = alphabet.AuthorId
        };
    }
}