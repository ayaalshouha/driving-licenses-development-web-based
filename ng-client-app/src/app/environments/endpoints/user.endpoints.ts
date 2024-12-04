import { environment } from '../environment';
export const USER_API_ENDPOINTS = {
  all: `${environment.apiBaseUrl}/User/All`,
  read: `${environment.apiBaseUrl}/User/Read?ID=`,
  create: `${environment.apiBaseUrl}/User/Create`,
  update: `${environment.apiBaseUrl}/User/Update`,
  readByUsername: `${environment.apiBaseUrl}/User/ReadByUsername?username=`,
  isExist: `${environment.apiBaseUrl}/User/isExistByID?ID=`,
};
