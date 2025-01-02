import { env } from 'process';
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

  cancel: (id: number) =>
    `${environment.apiBaseUrl}/localApplication/${id}/cancel`,
  issueLicense: (id: number, notes: string | null, userID: number) =>
    `${environment.apiBaseUrl}/localApplication/${id}/issue-license/${notes}/${userID}`,
  licenseID: (id: number) =>
    `${environment.apiBaseUrl}/localApplication/${id}/license-id`,
};
