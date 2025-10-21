import { buildSearchQuery } from '@/shared/helpers';
import { SortBy } from '@/shared/models';

export const pageUrls = {
  HOME: '/',
  HOME_: (searchText?: string, startIndex?: number, pageSize?: number, sortBy?: SortBy) => {
    const queryParams = buildSearchQuery(searchText, startIndex, pageSize, sortBy);
    return `${pageUrls.HOME}${queryParams}`;
  },
};
