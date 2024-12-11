import { environment } from '../environment';

export const LOCAL_APPLICATION_API_ENDPOINT = {
  all: `${environment.apiBaseUrl}/localApplication/local-applications`,
  create: `${environment.apiBaseUrl}/localApplication/`,
};
