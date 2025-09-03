using AsciiService.Entities;
using AsciiService.Models.Alphabet;
using AsciiService.Repositories.RepositoryBase;

namespace AsciiService.Repositories.AlphabetsRepository;

public interface IAlphabetsRepository : IRepositoryBase<Alphabet>
{
    Task<Alphabet> UpdateAsync(int alphabetId, string authorId, string authorName, AlphabetUpdateDto updateDto);
    Task<IEnumerable<Alphabet>> GetUserAlphabetsAsync(string userName);
    Task<IEnumerable<Alphabet>> GetUserPrivateAlphabetsAsync(string userId);
}