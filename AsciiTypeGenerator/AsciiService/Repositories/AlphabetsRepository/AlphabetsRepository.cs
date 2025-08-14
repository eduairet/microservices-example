using AsciiService.Data;
using AsciiService.Entities;
using AsciiService.Models.Alphabet;
using AsciiService.Repositories.RepositoryBase;
using Contracts;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace AsciiService.Repositories.AlphabetsRepository;

public class AlphabetsRepository(AppDbContext context, IPublishEndpoint publishEndpoint)
    : RepositoryBase<Alphabet>(context, publishEndpoint), IAlphabetsRepository
{
    protected override TContract FromEntityToCreateContract<TContract>(Alphabet entity) =>
        (TContract)(object)AlphabetDetailsDto.ToContractUpsert(entity);

    protected override TContract FromEntityToUpdateContract<TContract>(Alphabet entity) =>
        (TContract)(object)AlphabetDetailsDto.ToContractUpsert(entity);

    protected override TContract FromEntityToDeleteContract<TContract>(Alphabet entity) =>
        (TContract)(object)new AlphabetDeleted { Id = entity.Id };

    public new async Task<List<Alphabet>> GetAllAsync()
    {
        var alphabets = await context.Alphabets
            .Include(a => a.Author)
            .Include(a => a.Glyphs)
            .AsNoTracking()
            .ToListAsync();

        return alphabets;
    }

    public new async Task<Alphabet> GetAsync(object id)
    {
        var alphabet = await context.Alphabets
            .Include(a => a.Author)
            .Include(a => a.Glyphs)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == (int)id);

        return alphabet;
    }

    public async Task<IEnumerable<Alphabet>> GetUserAlphabetsAsync(int userId)
    {
        var alphabets = await context.Alphabets
            .Where(a => a.AuthorId == userId)
            .Include(a => a.Glyphs)
            .AsNoTracking()
            .ToListAsync();

        return alphabets;
    }
}