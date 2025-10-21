import { GATEWAY_SERVICE_URL } from '@/shared/constants';
import { buildSearchQuery } from '@/shared/helpers';
import { SortBy } from '@/shared/models';

export const gatewayService = {
  BASE_URL: GATEWAY_SERVICE_URL,
  SEARCH_PATH: '/search',
  SEARCH_ARTWORKS: `${GATEWAY_SERVICE_URL}/search/artworks`,
  search: {
    artworks: (searchText: string, startIndex: number, pageSize: number, sortBy?: SortBy) => {
      const queryParams = buildSearchQuery(searchText, startIndex, pageSize, sortBy);
      return `${gatewayService.SEARCH_ARTWORKS}${queryParams}`;
    },
  },
};
