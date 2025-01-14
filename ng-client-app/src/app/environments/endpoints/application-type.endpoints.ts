import { environment } from '../environment';

export const APPLICATION_TYPE_API_ENDPOINT = {
  add: `${environment.apiBaseUrl}/applicationType/`,
  all: `${environment.apiBaseUrl}/applicationType/application-types`,
  fees: (id: number) =>
    `${environment.apiBaseUrl}/applicationType/${id}/application-type-fees`,
};
