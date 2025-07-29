using MongoDB.Entities;
using SearchService.Models.Virtualize;

namespace SearchService.Repositories.SearchRepository;

public class SearchRepository : ISearchRepository
{
    public async Task<VirtualizeResponse<Entity>> SearchAsync(VirtualizeQueryParameters queryParameters)
    {
        var startIndex = queryParameters.StartIndex;
        var pageSize = queryParameters.PageSize;

        var totalCount = await DB.CountAsync<Entity>();

        if (totalCount == 0)
        {
            return new VirtualizeResponse<Entity>
            {
                Items = [],
                TotalCount = 0,
                PageCount = 0
            };
        }

        var query = DB.PagedSearch<Entity>();

        if (!string.IsNullOrWhiteSpace(queryParameters.SearchText))
            query.Match(Search.Full, queryParameters.SearchText).SortByTextScore();

        if (queryParameters.SortBy is not null && !string.IsNullOrWhiteSpace(queryParameters.SortBy.Field))
            query.Sort(x =>
                queryParameters.SortBy.Descending
                    ? x.Descending(queryParameters.SortBy.Field)
                    : x.Ascending(queryParameters.SortBy.Field));

        if (queryParameters.Filter?.Count > 0)
            foreach (var filter in queryParameters.Filter)
                query.Match(x => filter.Invoke());

        var result = await query
            .PageNumber(startIndex)
            .PageSize(pageSize)
            .ExecuteAsync();

        return new VirtualizeResponse<Entity>
        {
            Items = result.Results.ToList(),
            PageCount = result.PageCount,
            TotalCount = result.TotalCount,
        };
    }
}