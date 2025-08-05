using MongoDB.Entities;
using SearchService.Models.Virtualize;

namespace SearchService.Repositories.SearchRepository;

public interface ISearchRepository<T> where T : Entity
{
    Task<VirtualizeResponse<T>> SearchAsync(VirtualizeQueryParameters queryParameters);
}