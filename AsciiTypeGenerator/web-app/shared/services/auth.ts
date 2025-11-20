import { authService } from '@/shared/constants';
import { fetchData } from '@/shared/helpers';

export const login = async (email: string, password: string): Promise<string> =>
  (
    await fetchData(authService.login, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ email, password }),
    })
  ).text();
