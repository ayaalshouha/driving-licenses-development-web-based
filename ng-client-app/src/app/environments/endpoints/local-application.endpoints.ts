import { environment } from '../environment';

export const LOCAL_APPLICATION_API_ENDPOINT = {
  create: `${environment.apiBaseUrl}/LocalApplication/Create`,
  all: `${environment.apiBaseUrl}/LocalApplication/All`,
};
