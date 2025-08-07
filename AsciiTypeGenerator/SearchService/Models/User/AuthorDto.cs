using Contracts;

namespace SearchService.Models.User;

public class AuthorDto
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
}

public static class AuthorDtoEx
{
    public static Entities.User ToEntity(AuthorDto dto) => new()
    {
        ID = dto.Id.ToString(),
        UserId = dto.UserId,
        UserName = dto.UserName
    };
    
    public static Entities.User ToEntity(UserContract author) => new()
    {
        ID = author.Id.ToString(),
        UserId = author.UserId,
        UserName = author.UserName
    };
}