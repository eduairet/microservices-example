using MongoDB.Entities;
using SearchService.Models.Virtualize;

namespace SearchService.Repositories.SearchRepository;

public class SearchRepository : ISearchRepository
{
    public async Task<VirtualizeResponse<Entity>> SearchAsync(VirtualizeQueryParameters queryParameters,
        string searchText = null)
    {
        var startIndex = queryParameters.StartIndex;
        var pageSize = queryParameters.PageSize;

        var totalCount = await DB.CountAsync<Entity>();

        if (totalCount == 0)
        {
            return new VirtualizeResponse<Entity>
            {
                TotalCount = 0,
                Items = []
            };
        }

        var items = await DB.Find<Entity>()
            .Skip(startIndex)
            .Limit(pageSize)
            .ExecuteAsync();

        return new VirtualizeResponse<Entity>
        {
            TotalCount = totalCount,
            Items = items
        };
    }
}