import HomePagination from '@/components/layout/HomePagination';
import Heading, { HeadingLevel } from '@/components/text/Heading';
import Paragraph from '@/components/text/Paragraph';
import { useParamsStore } from '@/hooks/useParamsStore';
import { ArtworkListResponse, SearchQueryApi } from '@/shared/models';
import { searchArtworks } from '@/shared/services';

type Props = {
  searchParams: Promise<{ [key: string]: string } | undefined>;
};

export default async function Home({ searchParams }: Props) {
  const searchParamsObj = await searchParams;

  const searchText = searchParamsObj?.searchText;
  const page = parseInt(searchParamsObj?.page ?? '', 10);
  const pageSize = parseInt(searchParamsObj?.pageSize ?? '', 10);
  const sortBy = searchParamsObj?.SortBy;
  const sortDirection = searchParamsObj?.SortDirection as 'Asc' | 'Desc' | undefined;

  const artworks: ArtworkListResponse = await searchArtworks(
    new SearchQueryApi(searchText, page * pageSize, sortBy, sortDirection)
  );

  useParamsStore.setState({
    searchText,
    page,
    pageSize,
    pageCount: artworks.totalCount,
    sortBy,
    sortDirection,
  });

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
      <HomePagination />
    </div>
  );
}
