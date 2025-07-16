using AsciiService.Entities;
using AsciiService.Repositories.RepositoryBase;

namespace AsciiService.Repositories.AlphabetsRepository;

public interface IAlphabetsRepository : IRepositoryBase<Alphabet>
{
    Task<Alphabet> GetUserAlphabetsAsync(string userId);
}