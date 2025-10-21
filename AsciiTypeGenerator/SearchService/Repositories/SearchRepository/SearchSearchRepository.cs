using MongoDB.Entities;
using SearchService.Models.Virtualize;

namespace SearchService.Repositories.SearchRepository;

public class SearchRepository<T> : ISearchRepository<T>
    where T : Entity
{
    public async Task<VirtualizeResponse<T>> SearchAsync(VirtualizeQueryParameters queryParameters)
    {
        var startIndex = Math.Max(queryParameters.StartIndex, 1);
        var pageSize = queryParameters.PageSize;

        var totalCount = await DB.CountAsync<T>();

        if (totalCount == 0)
        {
            return new VirtualizeResponse<T>
            {
                Items = [],
                TotalCount = 0,
                PageCount = 0
            };
        }

        var query = DB.PagedSearch<T>();

        if (!string.IsNullOrWhiteSpace(queryParameters.SearchText))
            query.Match(Search.Full, queryParameters.SearchText).SortByTextScore();

        if (queryParameters.SortBy is not null && !string.IsNullOrWhiteSpace(queryParameters.SortBy))
        {
            query.Sort(x =>
                queryParameters.SortDirection == SortDirection.Desc
                    ? x.Descending(queryParameters.SortBy)
                    : x.Ascending(queryParameters.SortBy));
        }
        else
        {
            query.Sort(x => x.Descending(nameof(Entity.ID)));
        }

        var result = await query
            .PageNumber(startIndex)
            .PageSize(pageSize)
            .ExecuteAsync();

        return new VirtualizeResponse<T>
        {
            Items = result.Results.ToList(),
            PageCount = result.PageCount,
            TotalCount = result.TotalCount,
        };
    }
}