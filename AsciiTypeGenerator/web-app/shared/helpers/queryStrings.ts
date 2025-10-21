import { SearchQuery } from '@/shared/models';

export const buildSearchQuery = (query: SearchQuery) => {
  const searchTextQuery = query.SearchText
    ? `SearchText=${encodeURIComponent(query.SearchText)}`
    : '';
  const startIndexQuery = query.StartIndex ? `StartIndex=${query.StartIndex}` : '';
  const pageSizeQuery = query.PageSize ? `PageSize=${query.PageSize}` : '';
  const sortByFieldQuery = query.SortBy ? `SortBy=${encodeURIComponent(query.SortBy)}` : '';
  const sortByDirectionQuery = query.SortDirection ? `SortDirection=${query.SortDirection}` : '';

  const queryParams = [
    searchTextQuery,
    startIndexQuery,
    pageSizeQuery,
    sortByFieldQuery,
    sortByDirectionQuery,
  ]
    .filter(param => param)
    .join('&');

  return `/${queryParams ? `?${queryParams}` : ''}`;
};
