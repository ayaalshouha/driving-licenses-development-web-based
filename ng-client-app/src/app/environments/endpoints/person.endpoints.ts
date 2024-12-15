import { environment } from '../environment';
export const PERSON_API_ENDPOINTS = {
  all: `${environment.apiBaseUrl}/person/people`,
  read: `${environment.apiBaseUrl}/person/`,
  create: `${environment.apiBaseUrl}/person`,
  update: `${environment.apiBaseUrl}/person/`,
  delete: `${environment.apiBaseUrl}/person/`,
  isExist: (id: number) => `${environment.apiBaseUrl}/person/${id}/is-exist`,
  isExistNationalNo: (nationalNo: string) =>
    `${environment.apiBaseUrl}/person/No:${nationalNo}/is-exist`,
  fullName: (id: number) => `${environment.apiBaseUrl}/person/${id}/full-name`,
};
