using AutoMapper;
using AsciiTypeGenerator.Common.Models.Virtualize;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AsciiTypeGenerator.Common.Repositories.RepositoryBase;

public class RepositoryBase<T>(DbContext context, IMapper mapper) : IRepositoryBase<T> where T : class
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
            .ProjectTo<TResult>(mapper.ConfigurationProvider)
            .ToListAsync();

        return new VirtualizeResponse<TResult> { Items = items, TotalCount = totalCount };
    }

    public async Task<T> GetAsync(object id)
    {
        if (id is null) return null;
        var entity = await context.Set<T>().FindAsync(id) ??
                     throw new KeyNotFoundException(EntityNotFoundMessage(id.ToString()));
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
                     throw new KeyNotFoundException(EntityNotFoundMessage(id.ToString()));
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<bool> Exists(object id)
    {
        var entity = await context.Set<T>().FindAsync(id);
        return entity is not null;
    }

    private static string EntityNotFoundMessage(string id) => $"Entity with id {id} not found.";
}