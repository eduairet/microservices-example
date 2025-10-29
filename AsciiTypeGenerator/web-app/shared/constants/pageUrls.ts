import { buildSearchQueryClient } from '@/shared/helpers';
import { SearchQueryClient } from '@/shared/models';

export const pageUrls = {
  HOME: '/',
  HOME_: (
    searchText?: string,
    page?: number,
    pageSize?: number,
    sortBy?: string,
    sortDirection?: 'Asc' | 'Desc'
  ) => {
    const queryParams = buildSearchQueryClient(
      new SearchQueryClient(searchText, page, pageSize, sortBy, sortDirection)
    );
    return `${pageUrls.HOME}${queryParams}`;
  },
};
