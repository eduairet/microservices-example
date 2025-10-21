import { Artwork } from '@/shared/models';

export class ArtworkListResponse {
  constructor(
    public items: Artwork[],
    public pageCount: number,
    public totalCount: number
  ) {}
}
