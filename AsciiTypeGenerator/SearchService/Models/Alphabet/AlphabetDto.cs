using Contracts;
using SearchService.Models.Glyph;

namespace SearchService.Models.Alphabet;

public class AlphabetDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public string AuthorName { get; set; }
    public List<GlyphDto> Glyphs { get; set; }

    public static Entities.Alphabet ToEntity(AlphabetDto dto) => new()
    {
        ID = dto.Id.ToString(),
        Title = dto.Title,
        Description = dto.Description,
        CreatedAt = dto.CreatedAt,
        UpdatedAt = dto.UpdatedAt,
        AuthorName = dto.AuthorName,
        Glyphs = dto.Glyphs.Select(GlyphDto.ToEntity).ToList()
    };

    public static Entities.Alphabet ToEntity(AlphabetContract contract) => new()
    {
        ID = contract.Id.ToString(),
        Title = contract.Title,
        Description = contract.Description,
        CreatedAt = contract.CreatedAt,
        UpdatedAt = contract.UpdatedAt,
        AuthorName = contract.AuthorName,
        Glyphs = contract.Glyphs.Select(GlyphDto.ToEntity).ToList()
    };
}