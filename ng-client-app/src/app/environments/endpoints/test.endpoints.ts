import { environment } from '../environment';

export const TESTS_API_ENDPOINTS = {
  read: (id: number) => `${environment.apiBaseUrl}/test/${id}`,
  add: `${environment.apiBaseUrl}/test/new`,
  all: `${environment.apiBaseUrl}/test/tests`,
  count: `${environment.apiBaseUrl}/test/count`,
  passedPercentage: `${environment.apiBaseUrl}/test/passed-percetage`,
  faieldPercentage: `${environment.apiBaseUrl}/test/failed-percetage`,
};
