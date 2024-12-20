import { environment } from '../environment';

export const TESTS_API_ENDPOINTS = {
  all: `${environment.apiBaseUrl}/test/tests`,
  count: `${environment.apiBaseUrl}/test/counts`,
};
