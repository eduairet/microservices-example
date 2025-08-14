using Microsoft.EntityFrameworkCore;
using AsciiService.Shared.Constants;
using MassTransit;

namespace AsciiService.Repositories.RepositoryBase;

public class RepositoryBase<T>(DbContext context, IPublishEndpoint publishEndpoint) : IRepositoryBase<T> where T : class
{
    // Add function to map the entity into a generic type, it should be called FromEntityToCreateContract
    protected virtual TContract FromEntityToCreateContract<TContract>(T entity) where TContract : class
    {
        throw new NotImplementedException("FromEntityToCreateContract method is not implemented.");
    }

    protected virtual TContract FromEntityToUpdateContract<TContract>(T entity) where TContract : class
    {
        throw new NotImplementedException("FromEntityToUpdateContract method is not implemented.");
    }

    protected virtual TContract FromEntityToDeleteContract<TContract>(T entity) where TContract : class
    {
        throw new NotImplementedException("FromEntityToDeleteContract method is not implemented.");
    }

    public async Task<List<T>> GetAllAsync()
    {
        var entities = await context.Set<T>().AsNoTracking().ToListAsync();
        return entities;
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

        try
        {
            await publishEndpoint.Publish(FromEntityToUpdateContract<object>(entity));
        }
        catch (Exception)
        {
            // ignored
        }

        await context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        context.Update(entity);

        try
        {
            await publishEndpoint.Publish(FromEntityToUpdateContract<object>(entity));
        }
        catch (Exception)
        {
            // ignored
        }

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(object id)
    {
        var entity = await context.FindAsync<T>(id) ??
                     throw new KeyNotFoundException(ErrorMessages.EntityIdNotFound(id.ToString()));
        context.Set<T>().Remove(entity);

        try
        {
            await publishEndpoint.Publish(FromEntityToUpdateContract<object>(entity));
        }
        catch (Exception)
        {
            // ignored
        }

        await context.SaveChangesAsync();
    }

    public async Task<bool> Exists(object id)
    {
        var entity = await context.Set<T>().FindAsync(id);
        return entity is not null;
    }
}