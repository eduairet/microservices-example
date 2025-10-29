import {
  SEARCH_PAGE_SIZE_DEFAULT,
  SEARCH_SORT_BY_DEFAULT,
  SEARCH_SORT_DIRECTION_DEFAULT,
} from '@/shared/constants';

export class SearchQueryApi {
  constructor(
    public SearchText?: string,
    public StartIndex?: number,
    public SortBy?: string,
    public SortDirection?: 'Asc' | 'Desc',
    public PageSize?: number | null
  ) {
    this.SearchText = SearchText || '';
    this.StartIndex = StartIndex || 0;
    this.PageSize = PageSize || SEARCH_PAGE_SIZE_DEFAULT;
    this.SortBy = SortBy || SEARCH_SORT_BY_DEFAULT;
    this.SortDirection = SortDirection || SEARCH_SORT_DIRECTION_DEFAULT;
  }
}

export class SearchQueryClient {
  constructor(
    public searchText?: string | undefined,
    public page?: number | undefined,
    public pageSize?: number | undefined,
    public sortBy?: string | undefined,
    public sortDirection?: 'Asc' | 'Desc' | undefined
  ) {
    this.searchText = searchText;
    this.page = page;
    this.pageSize = pageSize;
    this.sortBy = sortBy;
    this.sortDirection = sortDirection;
  }
}
