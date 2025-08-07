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
    public AuthorDto Author { get; set; } = new();
    public List<GlyphDto> Glyphs { get; set; } = [];
}

public static class AlphabetDtoEx
{
    public static Entities.Alphabet ToEntity(AlphabetDto dto) => new()
    {
        ID = dto.Id.ToString(),
        Title = dto.Title,
        Description = dto.Description,
        CreatedAt = dto.CreatedAt,
        UpdatedAt = dto.UpdatedAt,
        Author = dto.Author is null ? null : AuthorDtoEx.ToEntity(dto.Author),
        Glyphs = dto.Glyphs.Select(GlyphDtoEx.ToEntity).ToList()
    };
    
    public static Entities.Alphabet ToEntity(AlphabetContract alphabet) => new()
    {
        ID = alphabet.Id.ToString(),
        Title = alphabet.Title,
        Description = alphabet.Description,
        CreatedAt = alphabet.CreatedAt,
        UpdatedAt = alphabet.UpdatedAt,
        Author = AuthorDtoEx.ToEntity(alphabet.Author),
        Glyphs = alphabet.Glyphs.Select(GlyphDtoEx.ToEntity).ToList()
    };
}