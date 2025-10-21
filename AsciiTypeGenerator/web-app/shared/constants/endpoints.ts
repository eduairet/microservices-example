import { GATEWAY_SERVICE_URL } from '@/shared/constants';
import { buildSearchQuery } from '@/shared/helpers';
import { SearchQuery } from '@/shared/models';

export const gatewayService = {
  SEARCH_ARTWORKS: `${GATEWAY_SERVICE_URL}/search/artworks`,
  search: {
    artworks: (query: SearchQuery) => {
      const queryParams = buildSearchQuery(query);
      return `${gatewayService.SEARCH_ARTWORKS}${queryParams}`;
    },
  },
};
