import { SortBy } from '@/shared/models';

export const SEARCH_START_INDEX_DEFAULT = 0;
export const SEARCH_PAGE_SIZE_DEFAULT = 10;
export const SEARCH_SORT_BY_DEFAULT: SortBy = {
  Field: 'searchText',
  Descending: true,
};
