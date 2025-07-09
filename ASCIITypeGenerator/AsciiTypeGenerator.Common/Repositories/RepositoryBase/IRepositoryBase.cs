using AsciiTypeGenerator.Common.Models.Virtualize;

namespace AsciiTypeGenerator.Common.Repositories.RepositoryBase;

public interface IRepositoryBase<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<VirtualizeResponse<TResult>> GetAllAsync<TResult>(VirtualizeQueryParameters queryParam) where TResult : class;
    Task<T> GetAsync(object id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(object id);
    Task<bool> Exists(object id);
}