using AsciiService.Entities;

namespace AsciiService.Models.Alphabets;

public class AlphabetUpsertDto
{
    private string Title { get; set; } = string.Empty;
    private string Description { get; set; } = string.Empty;
    private string Characters { get; set; } = string.Empty;

    public Alphabet ToEntity(string authorId)
    {
        return new Alphabet
        {
            Title = Title,
            Description = Description,
            Characters = Characters,
            AuthorId = authorId
        };
    }
    
    public Alphabet ToEntity(string id, string authorId)
    {
        return new Alphabet
        {
            Id = id,
            Title = Title,
            Description = Description,
            Characters = Characters,
            AuthorId = authorId
        };
    }
}