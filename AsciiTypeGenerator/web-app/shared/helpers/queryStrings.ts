import { SearchQueryApi, SearchQueryClient } from '@/shared/models';

export const buildSearchQueryApi = (query: SearchQueryApi) => {
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

export const buildSearchQueryClient = (query: SearchQueryClient) => {
  const searchTextQuery = query.searchText
    ? `searchText=${encodeURIComponent(query.searchText)}`
    : '';
  const pageQuery = query.page ? `page=${query.page}` : '';
  const pageSizeQuery = query.pageSize ? `pageSize=${query.pageSize}` : '';
  const sortByFieldQuery = query.sortBy ? `sortBy=${encodeURIComponent(query.sortBy)}` : '';
  const sortByDirectionQuery = query.sortDirection ? `sortDirection=${query.sortDirection}` : '';

  const queryParams = [
    searchTextQuery,
    pageQuery,
    pageSizeQuery,
    sortByFieldQuery,
    sortByDirectionQuery,
  ]
    .filter(param => param)
    .join('&');

  return `/${queryParams ? `?${queryParams}` : ''}`;
};
