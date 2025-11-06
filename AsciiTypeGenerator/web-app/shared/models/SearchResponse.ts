import { Artwork } from '@/shared/models';

export class SearchResponse<T> {
  constructor(
    public items: T[],
    public pageCount: number,
    public totalCount: number
  ) {}
}
