import { env } from 'process';
import { environment } from '../environment';
export const INTERNATIONAL_API_ENDPOINTS = {
  read: (id: number) => `${environment.apiBaseUrl}/internationalLicense/${id}`,
  all: `${environment.apiBaseUrl}/internationalLicense/international-licenses`,
};
