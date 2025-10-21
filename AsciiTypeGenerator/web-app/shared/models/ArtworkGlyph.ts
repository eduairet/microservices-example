import { Glyph } from '@/shared/models';

export class ArtworkGlyph {
  constructor(
    public index: number,
    public glyph: Glyph,
    public id: string | null = null
  ) {}
}
