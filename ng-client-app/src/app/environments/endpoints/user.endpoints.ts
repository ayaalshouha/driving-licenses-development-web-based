import { environment } from '../environment';
export const USER_API_ENDPOINTS = {
  all: `${environment.apiBaseUrl}/user/users`,
  read: `${environment.apiBaseUrl}/user/`,
  create: `${environment.apiBaseUrl}/user`,
  update: `${environment.apiBaseUrl}/user/`,
  delete: `${environment.apiBaseUrl}/user/`,
  readByUsername: `${environment.apiBaseUrl}/user/user:`,
  isExist: (id: number) => `${environment.apiBaseUrl}/user/${id}/existance`,
};
