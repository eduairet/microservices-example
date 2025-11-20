import { AUTH_SERVICE_URL, GATEWAY_SERVICE_URL } from '@/shared/constants';
import { buildSearchQueryApi } from '@/shared/helpers';
import { SearchQueryApi } from '@/shared/models';

const SEARCH_ARTWORKS = `${GATEWAY_SERVICE_URL}/search/artworks`;
export const gatewayService = {
  search: {
    artworks: (query: SearchQueryApi) => {
      const queryParams = buildSearchQueryApi(query);
      return `${SEARCH_ARTWORKS}${queryParams}`;
    },
  },
};

const AUTH_BASE = `${AUTH_SERVICE_URL}/api/v1/auth`;
export const authService = {
  login: `${AUTH_BASE}/login`,
  register: `${AUTH_BASE}/register`,
};
