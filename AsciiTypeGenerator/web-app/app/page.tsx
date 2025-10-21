import Heading, { HeadingLevel } from '@/components/text/Heading';
import Paragraph from '@/components/text/Paragraph';
import { gatewayService } from '@/shared/constants/endpoints';
import { fetchData } from '@/shared/helpers';
import { ArtworkListResponse } from '@/shared/models';

export default async function Home() {
  const searchParams = new URLSearchParams(
    typeof window !== 'undefined' ? window.location.search : ''
  );

  const searchText = searchParams.get('SearchText') || '';
  const startIndex = Number(searchParams.get('StartIndex')) || 0;
  const pageSize = Number(searchParams.get('PageSize')) || 10;

  /* TODO: Fix API to accept SortBy properly
  const sortByField = searchParams.get('SortBy.Field') || 'SearchText';
  const sortByDescending = searchParams.get('SortBy.Descending') === 'true';
  */

  const artworks: ArtworkListResponse = await fetchData(
    gatewayService.search.artworks(searchText, startIndex, pageSize),
    { cache: 'force-cache' }
  );

  return (
    <div className="flex flex-col gap-6 justify-center w-full h-full">
      <Heading level={HeadingLevel.H1} className="flex flex-col gap-2 justify-center">
        <span>Ascii</span>
        <span className="text-foreground">Type</span>
        <span>Generator</span>
      </Heading>
      <Paragraph>
        Generate ASCII art from text using different fonts created by the community.
      </Paragraph>
      <p>{JSON.stringify(artworks)}</p>
    </div>
  );
}
