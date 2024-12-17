import { environment } from '../environment';

export const TEST_TYPE_API_ENDPOINT = {
  all: `${environment.apiBaseUrl}/testType/test-types`,
  read: `${environment.apiBaseUrl}/testType/`,
  fee: (id: number) => `${environment.apiBaseUrl}/testType/${id}/fee`,
};
