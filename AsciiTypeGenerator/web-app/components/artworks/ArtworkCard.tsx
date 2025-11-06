import { FC } from 'react';
import CardWrapper from '../layout/CardWrapper';
import { Artwork } from '@/shared/models';

const ArtworkCard: FC<{ artwork: Artwork }> = ({ artwork }) => {
  return (
    <CardWrapper>
      <h2 className="text-3xl font-bold text-accent mb-2">{artwork.title}</h2>
      <div className="mb-4 text-sm text-muted">
        <p>
          {/* Implement Author Name Slug */}
          By: <a href="#">{artwork.authorName ? artwork.authorName : 'Unknown'}</a>
        </p>
        {artwork.updatedAt && (
          <p>
            Updated At:{' '}
            <time dateTime={artwork.updatedAt}>
              {new Date(artwork.updatedAt).toLocaleDateString()}
            </time>
          </p>
        )}
      </div>
      <p className="text-lg mb-2">{artwork.description}</p>
      <div className="flex items-center p-9 bg-background text-accent overflow-x-auto rounded-md h-auto">
        {artwork.artworkGlyphs.map(artworkGlyph => (
          <div
            key={`artwork-${artwork.id}-glyph-${artworkGlyph.index}`}
            className="flex flex-col font-mono font-extrabold leading-[1] text-3xl"
          >
            {artworkGlyph.glyph.drawing.split('\n').map((line, index) => (
              <span key={`artwork-${artwork.id}-glyph-${artworkGlyph.index}-line-${index}`}>
                {[...line].map((char, charIndex) => (
                  <span
                    key={`artwork-${artwork.id}-glyph-${artworkGlyph.index}-line-${index}-char-${charIndex}`}
                    className={char === 'W' ? 'text-pink-500' : 'text-background'}
                  >
                    {typeof artworkGlyph.glyph.unicode === 'number'
                      ? String.fromCodePoint(artworkGlyph.glyph.unicode)
                      : artworkGlyph.glyph.unicode}
                  </span>
                ))}
              </span>
            ))}
          </div>
        ))}
      </div>
    </CardWrapper>
  );
};

export default ArtworkCard;
