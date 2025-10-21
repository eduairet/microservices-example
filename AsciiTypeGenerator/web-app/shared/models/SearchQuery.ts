import {
  SEARCH_PAGE_SIZE_DEFAULT,
  SEARCH_SORT_BY_DEFAULT,
  SEARCH_SORT_DIRECTION_DEFAULT,
  SEARCH_START_INDEX_DEFAULT,
} from '@/shared/constants';

export class SearchQuery {
  constructor(
    public SearchText?: string,
    public StartIndex?: number,
    public SortBy?: string,
    public SortDirection?: 'Asc' | 'Desc',
    public PageSize?: number | null
  ) {
    this.SearchText = SearchText || '';
    this.StartIndex = StartIndex || SEARCH_START_INDEX_DEFAULT;
    this.PageSize = PageSize || SEARCH_PAGE_SIZE_DEFAULT;
    this.SortBy = SortBy || SEARCH_SORT_BY_DEFAULT;
    this.SortDirection = SortDirection || SEARCH_SORT_DIRECTION_DEFAULT;
  }
}
