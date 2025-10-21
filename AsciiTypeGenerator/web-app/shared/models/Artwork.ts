import { ArtworkGlyph } from '@/shared/models';

export class Artwork {
  constructor(
    public title: string,
    public description: string,
    public createdAt: string,
    public updatedAt: string,
    public authorName: string | null,
    public artworkGlyphs: ArtworkGlyph[],
    public id: string
  ) {}
}
