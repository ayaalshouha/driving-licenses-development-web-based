import { environment } from '../environment';

export const APPLICATION_API_ENDPOINT = {
  create: `${environment.apiBaseUrl}/Application/Create`,
  all: `${environment.apiBaseUrl}/Application/All`,
};
