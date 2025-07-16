using AsciiService.Data;
using AsciiService.Entities;
using AsciiService.Repositories.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace AsciiService.Repositories.AlphabetsRepository;

public class AlphabetsRepository(AppDbContext context) : RepositoryBase<Alphabet>(context), IAlphabetsRepository
{
    public async Task<Alphabet> GetUserAlphabetsAsync(string userId)
    {
        if (string.IsNullOrEmpty(userId))
            throw new ArgumentNullException(nameof(userId), "User ID cannot be null or empty.");

        var alphabet = await context.Alphabets
            .FirstOrDefaultAsync(a => a.AuthorId == userId);

        return alphabet ?? throw new KeyNotFoundException($"No alphabet found for user ID: {userId}");
    }
}