export class Glyph {
  constructor(
    public name: string,
    public unicode: number,
    public drawing: string,
    public id: string | null = null
  ) {}
}
