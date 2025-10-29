import { GATEWAY_SERVICE_URL } from '@/shared/constants';
import { buildSearchQueryApi } from '@/shared/helpers';
import { SearchQueryApi } from '@/shared/models';

export const gatewayService = {
  SEARCH_ARTWORKS: `${GATEWAY_SERVICE_URL}/search/artworks`,
  search: {
    artworks: (query: SearchQueryApi) => {
      const queryParams = buildSearchQueryApi(query);
      return `${gatewayService.SEARCH_ARTWORKS}${queryParams}`;
    },
  },
};
