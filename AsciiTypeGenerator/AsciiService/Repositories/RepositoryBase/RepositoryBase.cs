using AsciiService.Models.Virtualize;
using Microsoft.EntityFrameworkCore;
using AsciiService.Shared.Constants;

namespace AsciiService.Repositories.RepositoryBase;

public class RepositoryBase<T>(DbContext context) : IRepositoryBase<T> where T : class
{
    public async Task<List<T>> GetAllAsync()
    {
        var entities = await context.Set<T>().AsNoTracking().ToListAsync();
        return entities;
    }

    public async Task<VirtualizeResponse<T>> GetAllAsync(VirtualizeQueryParameters queryParameters,
        string searchText = null)
    {
        var query = context.Set<T>().AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchText))
        {
            var stringProperties = typeof(T).GetProperties()
                .Where(p => p.PropertyType == typeof(string));

            query = stringProperties.Aggregate(query,
                (current, prop) =>
                    current.Where(e => EF.Functions.Like(EF.Property<string>(e, prop.Name), $"%{searchText}%")));
        }

        var totalCount = await query.CountAsync();
        var items = await query
            .Skip(queryParameters.StartIndex)
            .Take(queryParameters.PageSize)
            .AsNoTracking()
            .ToListAsync();

        return new VirtualizeResponse<T> { Items = items, TotalCount = totalCount };
    }

    public async Task<T> GetAsync(object id)
    {
        if (id is null) return null;
        var entity = await context.Set<T>().FindAsync(id) ??
                     throw new KeyNotFoundException(ErrorMessages.EntityIdNotFound(id.ToString()));
        return entity;
    }

    public async Task<T> AddAsync(T entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        context.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(object id)
    {
        var entity = await context.FindAsync<T>(id) ??
                     throw new KeyNotFoundException(ErrorMessages.EntityIdNotFound(id.ToString()));
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<bool> Exists(object id)
    {
        var entity = await context.Set<T>().FindAsync(id);
        return entity is not null;
    }
}