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
        (TContract)(object)AlphabetDetailsDto.ToContractCreate(entity);

    protected override TContract FromEntityToUpdateContract<TContract>(Alphabet entity) =>
        (TContract)(object)AlphabetDetailsDto.ToContractUpdate(entity);

    protected override TContract FromEntityToDeleteContract<TContract>(Alphabet entity) =>
        (TContract)(object)new AlphabetDeleted { Id = entity.Id };

    public new async Task<List<Alphabet>> GetAllAsync()
    {
        var alphabets = await context.Alphabets
            .Include(a => a.Glyphs)
            .AsNoTracking()
            .ToListAsync();

        return alphabets;
    }

    public new async Task<Alphabet> GetAsync(object id)
    {
        var alphabet = await context.Alphabets
            .Include(a => a.Glyphs)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == (int)id);

        return alphabet;
    }

    public async Task<Alphabet> UpdateAsync(int alphabetId, string authorId, string authorName,
        AlphabetUpdateDto updateDto)
    {
        var alphabet = await context.Alphabets
            .Include(a => a.Glyphs)
            .FirstOrDefaultAsync(a => a.Id == alphabetId);

        alphabet.Title = updateDto.Title;
        alphabet.Description = updateDto.Description;
        alphabet.UpdatedAt = DateTime.UtcNow;
        alphabet.AuthorName = authorName;
        alphabet.AuthorId = authorId;

        var glyphsToKeep = new List<Glyph>();
        foreach (var glyphDto in updateDto.Glyphs)
        {
            if (glyphDto.Id is null)
            {
                var newGlyph = new Glyph
                {
                    Name = glyphDto.Name,
                    Unicode = glyphDto.Unicode,
                    Drawing = glyphDto.Drawing,
                    AlphabetId = alphabetId
                };
                context.Glyphs.Add(newGlyph);
                glyphsToKeep.Add(newGlyph);
            }
            else
            {
                var existingGlyph = await context.Glyphs.FirstOrDefaultAsync(g => g.Id == glyphDto.Id);

                if (existingGlyph is null || existingGlyph.AlphabetId != alphabetId) continue;

                existingGlyph.Name = glyphDto.Name;
                existingGlyph.Unicode = glyphDto.Unicode;
                existingGlyph.Drawing = glyphDto.Drawing;
                glyphsToKeep.Add(existingGlyph);
            }
        }

        var glyphIdsToKeep = glyphsToKeep.Where(g => g.Id != 0).Select(g => g.Id).ToHashSet();
        var glyphsToRemove = alphabet.Glyphs.Where(g => !glyphIdsToKeep.Contains(g.Id)).ToList();

        foreach (var glyph in glyphsToRemove) context.Glyphs.Remove(glyph);

        alphabet.Glyphs = glyphsToKeep;

        await context.SaveChangesAsync();
        return alphabet;
    }

    public async Task<IEnumerable<Alphabet>> GetUserAlphabetsAsync(string userId)
    {
        var alphabets = await context.Alphabets
            .Where(a => a.AuthorId == userId)
            .Include(a => a.Glyphs)
            .AsNoTracking()
            .ToListAsync();

        return alphabets;
    }
}