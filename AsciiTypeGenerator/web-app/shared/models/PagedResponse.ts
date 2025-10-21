export class PagedResponse<T> {
  constructor(
    public items: T[],
    public pageCount: number,
    public totalCount: number
  ) {}
}
