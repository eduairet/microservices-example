using Contracts;
using SearchService.Models.Glyph;
using SearchService.Models.User;

namespace SearchService.Models.Alphabet;

public class AlphabetDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public AuthorDto Author { get; set; }
    public List<GlyphDto> Glyphs { get; set; }

    public static Entities.Alphabet ToEntity(AlphabetDto dto) => new()
    {
        ID = dto.Id.ToString(),
        Title = dto.Title,
        Description = dto.Description,
        CreatedAt = dto.CreatedAt,
        UpdatedAt = dto.UpdatedAt,
        Author = dto.Author is null ? null : AuthorDto.ToEntity(dto.Author),
        Glyphs = dto.Glyphs.Select(GlyphDto.ToEntity).ToList()
    };

    public static Entities.Alphabet ToEntity(AlphabetContract contract) => new()
    {
        ID = contract.Id.ToString(),
        Title = contract.Title,
        Description = contract.Description,
        CreatedAt = contract.CreatedAt,
        UpdatedAt = contract.UpdatedAt,
        Author = contract.Author is null ? null : AuthorDto.ToEntity(contract.Author),
        Glyphs = contract.Glyphs.Select(GlyphDto.ToEntity).ToList()
    };
}