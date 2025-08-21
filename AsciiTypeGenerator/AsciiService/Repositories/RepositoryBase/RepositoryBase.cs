using Microsoft.EntityFrameworkCore;
using AsciiService.Shared.Constants.Messages;
using MassTransit;

namespace AsciiService.Repositories.RepositoryBase;

public class RepositoryBase<T>(DbContext context, IPublishEndpoint publishEndpoint) : IRepositoryBase<T> where T : class
{
    protected virtual TContract FromEntityToCreateContract<TContract>(T entity) where TContract : class
    {
        throw new NotImplementedException(Messages.Error.MethodNotImplemented(nameof(FromEntityToCreateContract)));
    }

    protected virtual TContract FromEntityToUpdateContract<TContract>(T entity) where TContract : class
    {
        throw new NotImplementedException(Messages.Error.MethodNotImplemented(nameof(FromEntityToUpdateContract)));
    }

    protected virtual TContract FromEntityToDeleteContract<TContract>(T entity) where TContract : class
    {
        throw new NotImplementedException(Messages.Error.MethodNotImplemented(nameof(FromEntityToDeleteContract)));
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
                     throw new KeyNotFoundException(Messages.Error.EntityIdNotFound(id.ToString()));
        return entity;
    }

    public async Task<T> AddAsync(T entity)
    {
        await context.AddAsync(entity);

        try
        {
            await publishEndpoint.Publish(FromEntityToCreateContract<object>(entity));
        }
        catch (Exception)
        {
            // ignored
        }

        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
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
        return entity;
    }

    public async Task DeleteAsync(object id)
    {
        var entity = await context.FindAsync<T>(id) ??
                     throw new KeyNotFoundException(Messages.Error.EntityIdNotFound(id.ToString()));
        context.Set<T>().Remove(entity);

        try
        {
            await publishEndpoint.Publish(FromEntityToDeleteContract<object>(entity));
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