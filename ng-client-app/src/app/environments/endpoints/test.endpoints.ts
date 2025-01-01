import { environment } from '../environment';

export const TESTS_API_ENDPOINTS = {
  add: `${environment.apiBaseUrl}/test`,
  all: `${environment.apiBaseUrl}/test/tests`,
  count: `${environment.apiBaseUrl}/test/count`,
  passedPercentage: `${environment.apiBaseUrl}/test/passed-percetage`,
  faieldPercentage: `${environment.apiBaseUrl}/test/failed-percetage`,
};
