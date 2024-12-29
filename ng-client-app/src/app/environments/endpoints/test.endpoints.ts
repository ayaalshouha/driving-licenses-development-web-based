import { environment } from '../environment';

export const TESTS_API_ENDPOINTS = {
  add: `${environment.apiBaseUrl}/test`,
  all: `${environment.apiBaseUrl}/test/tests`,
  count: `${environment.apiBaseUrl}/test/count`,
};
