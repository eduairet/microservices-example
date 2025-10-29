import { gatewayService } from '@/shared/constants';
import { fetchData } from '@/shared/helpers';
import { ArtworkListResponse, SearchQueryApi } from '@/shared/models';

export const searchArtworks = async (query: SearchQueryApi): Promise<ArtworkListResponse> =>
  await fetchData(gatewayService.search.artworks(query), { cache: 'force-cache' });
