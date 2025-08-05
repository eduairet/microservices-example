using MongoDB.Entities;

namespace SearchService.Entities;

public class User : Entity
{
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
}