import { gatewayService } from '@/shared/constants';
import { fetchData } from '@/shared/helpers';
import { ArtworkListResponse, SearchQuery } from '@/shared/models';

export const searchArtworks = async (query: SearchQuery): Promise<ArtworkListResponse> =>
  await fetchData(gatewayService.search.artworks(query), { cache: 'force-cache' });
