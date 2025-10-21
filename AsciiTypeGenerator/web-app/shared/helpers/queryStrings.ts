import { SortBy } from '@/shared/models';

export const buildSearchQuery = (
  searchText?: string,
  startIndex?: number,
  pageSize?: number,
  sortBy?: SortBy
) => {
  const searchTextQuery = searchText ? `SearchText=${encodeURIComponent(searchText)}` : '';
  const startIndexQuery = startIndex ? `StartIndex=${startIndex}` : '';
  const pageSizeQuery = pageSize ? `PageSize=${pageSize}` : '';
  const sortByFieldQuery = sortBy ? `SortBy.Field=${encodeURIComponent(sortBy.Field)}` : '';
  const sortByDirectionQuery = sortBy
    ? `SortBy.Descending=${sortBy.Descending ? 'true' : 'false'}`
    : '';

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
