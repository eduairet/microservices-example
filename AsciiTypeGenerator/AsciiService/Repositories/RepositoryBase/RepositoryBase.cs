using AsciiTypeGenerator.Common.Models.Virtualize;
using Microsoft.EntityFrameworkCore;
using AsciiService.Shared.Constants;

namespace AsciiService.Repositories.RepositoryBase;

public class RepositoryBase<T>(DbContext context) : IRepositoryBase<T> where T : class
{
    public async Task<List<T>> GetAllAsync()
    {
        var entities = await context.Set<T>().ToListAsync();
        return entities;
    }

    public async Task<VirtualizeResponse<TResult>> GetAllAsync<TResult>(VirtualizeQueryParameters queryParameters)
        where TResult : class
    {
        var totalCount = await context.Set<T>().CountAsync();
        var items = await context.Set<T>()
            .Skip(queryParameters.StartIndex)
            .Take(queryParameters.PageSize)
            .Cast<TResult>()
            .ToListAsync();

        return new VirtualizeResponse<TResult> { Items = items, TotalCount = totalCount };
    }

    public async Task<T> GetAsync(object id)
    {
        if (id is null) return null;
        var entity = await context.Set<T>().FindAsync(id) ??
                     throw new KeyNotFoundException(Constants.ErrorMessages.EntityIdNotFound(id.ToString()));
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
                     throw new KeyNotFoundException(Constants.ErrorMessages.EntityIdNotFound(id.ToString()));
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<bool> Exists(object id)
    {
        var entity = await context.Set<T>().FindAsync(id);
        return entity is not null;
    }
}