import { env } from 'process';
import { environment } from '../environment';

export const APPOINTMENT_API_ENDPOINT = {
  add: `${environment.apiBaseUrl}/appointment`,
};
