import { environment } from '../environment';

export const LOCAL_APPLICATION_API_ENDPOINT = {
  create: `${environment.apiBaseUrl}/localApplication/`,
  all: `${environment.apiBaseUrl}/localApplication/local-applications`,
};
