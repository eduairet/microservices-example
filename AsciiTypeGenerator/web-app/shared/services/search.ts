import { gatewayService } from '@/shared/constants';
import { fetchData } from '@/shared/helpers';
import { SearchResponse, SearchQueryApi, Artwork } from '@/shared/models';

export const searchArtworks = async (query: SearchQueryApi): Promise<SearchResponse<Artwork>> =>
  (await fetchData(gatewayService.search.artworks(query), { cache: 'force-cache' })).json();
