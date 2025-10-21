import { buildSearchQuery } from '@/shared/helpers';
import { SearchQuery } from '@/shared/models';

export const pageUrls = {
  HOME: '/',
  HOME_: (
    searchText?: string,
    startIndex?: number,
    sortBy?: string,
    sortDirection?: 'Asc' | 'Desc'
  ) => {
    const queryParams = buildSearchQuery(
      new SearchQuery(searchText, startIndex, sortBy, sortDirection)
    );
    return `${pageUrls.HOME}${queryParams}`;
  },
};
