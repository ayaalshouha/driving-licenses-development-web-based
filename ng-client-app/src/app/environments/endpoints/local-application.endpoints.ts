import { environment } from '../environment';

export const LOCAL_APPLICATION_API_ENDPOINT = {
  all: `${environment.apiBaseUrl}/localApplication/local-applications`,
  create: `${environment.apiBaseUrl}/localApplication/`,
  read: `${environment.apiBaseUrl}/localApplication/`,
  readView: (id: number) =>
    `${environment.apiBaseUrl}/localApplication/${id}/view`,
  passedTestCount: (id: number) =>
    `${environment.apiBaseUrl}/localApplication/${id}/passed-test-count`,
  isTestAttended: (id: number, testID: number) =>
    `${environment.apiBaseUrl}/localApplication/${id}/is-test-attended/${testID}`,
  isLicenseIssued: (id: number) =>
    `${environment.apiBaseUrl}/localApplication/${id}/license-issued`,
};
