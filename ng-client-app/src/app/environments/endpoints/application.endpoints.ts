import { environment } from '../environment';

export const APPLICATION_API_ENDPOINT = {
  create: `${environment.apiBaseUrl}/application`,
  read: `${environment.apiBaseUrl}/application/`,
  count: `${environment.apiBaseUrl}/application/count`,
  
};
