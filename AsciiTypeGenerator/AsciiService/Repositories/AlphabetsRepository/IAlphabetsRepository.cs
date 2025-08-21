using AsciiService.Entities;
using AsciiService.Models.Alphabet;
using AsciiService.Repositories.RepositoryBase;

namespace AsciiService.Repositories.AlphabetsRepository;

public interface IAlphabetsRepository : IRepositoryBase<Alphabet>
{
    Task<Alphabet> UpdateAsync(int alphabetId, AlphabetUpdateDto updateDto);
    Task<IEnumerable<Alphabet>> GetUserAlphabetsAsync(string userId);
}