using MongoDB.Entities;
using SearchService.Models.Virtualize;

namespace SearchService.Repositories.SearchRepository;

public interface ISearchRepository
{
    Task<VirtualizeResponse<Entity>> SearchAsync(VirtualizeQueryParameters queryParameters,
        string searchText = null);
}