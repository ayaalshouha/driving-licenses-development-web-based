import { environment } from '../environment';

export const APPLICATION_TYPE_API_ENDPOINT = {
  all: `${environment.apiBaseUrl}/ApplicationType/application-types`,
  fees: (id: number) =>
    `${environment.apiBaseUrl}/applicationType/${id}/application-type-fees`,
};
