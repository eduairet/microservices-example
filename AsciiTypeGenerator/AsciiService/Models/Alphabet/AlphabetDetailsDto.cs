using AsciiService.Entities;
using AsciiService.Models.Glyph;
using Contracts;

namespace AsciiService.Models.Alphabet;

public class AlphabetDetailsDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public User Author { get; set; } = new();
    public List<GlyphDetailsDto> Glyphs { get; set; } = [];

    public static AlphabetDetailsDto FromEntity(Entities.Alphabet alphabet) => new()
    {
        Id = alphabet.Id,
        Title = alphabet.Title,
        Description = alphabet.Description,
        CreatedAt = alphabet.CreatedAt,
        UpdatedAt = alphabet.UpdatedAt,
        Author = alphabet.Author,
        Glyphs = alphabet.Glyphs.Select(GlyphDetailsDto.FromEntity).ToList()
    };


    public static AlphabetCreated ToContractCreate(Entities.Alphabet alphabet) => new()
    {
        Id = alphabet.Id,
        Title = alphabet.Title,
        Description = alphabet.Description,
        CreatedAt = alphabet.CreatedAt,
        UpdatedAt = alphabet.UpdatedAt,
        Author = alphabet.Author is not null
            ? new UserContract
            {
                Id = alphabet.Author.Id,
                UserName = alphabet.Author?.UserName
            }
            : null,
        Glyphs = alphabet.Glyphs.Select(GlyphDetailsDto.ToContract).ToList()
    };
    
    public static AlphabetUpdated ToContractUpdate(Entities.Alphabet alphabet) => new()
    {
        Id = alphabet.Id,
        Title = alphabet.Title,
        Description = alphabet.Description,
        CreatedAt = alphabet.CreatedAt,
        UpdatedAt = alphabet.UpdatedAt,
        Author = alphabet.Author is not null
            ? new UserContract
            {
                Id = alphabet.Author.Id,
                UserName = alphabet.Author?.UserName
            }
            : null,
        Glyphs = alphabet.Glyphs.Select(GlyphDetailsDto.ToContract).ToList()
    };
}