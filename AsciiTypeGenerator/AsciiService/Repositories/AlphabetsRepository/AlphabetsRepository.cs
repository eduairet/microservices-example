using AsciiService.Data;
using AsciiService.Entities;
using AsciiService.Repositories.RepositoryBase;
using AsciiService.Shared.Constants;
using Microsoft.EntityFrameworkCore;

namespace AsciiService.Repositories.AlphabetsRepository;

public class AlphabetsRepository(AppDbContext context) : RepositoryBase<Alphabet>(context), IAlphabetsRepository
{
    public new async Task<List<Alphabet>> GetAllAsync()
    {
        var alphabets = await context.Alphabets
            .Include(a => a.Author)
            .Include(a => a.Glyphs)
            .AsNoTracking()
            .ToListAsync();

        return alphabets;
    }
    public async Task<Alphabet> GetUserAlphabetsAsync(int userId)
    {
        var alphabet = await context.Alphabets
            .FirstOrDefaultAsync(a => a.AuthorId == userId);

        return alphabet ?? throw new KeyNotFoundException(ErrorMessages.NoAlphabetsForUser(userId.ToString()));
    }
}