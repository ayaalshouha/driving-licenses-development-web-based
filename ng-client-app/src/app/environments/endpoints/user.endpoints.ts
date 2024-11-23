import { environment } from '../environment';
export const USER_API_ENDPOINTS = {
  allUsers: `${environment.apiBaseUrl}/User/All`,
  addUser: `${environment.apiBaseUrl}/User/Create`,
  updateUser: `${environment.apiBaseUrl}/User/Update`,
  readUser: `${environment.apiBaseUrl}/User/Read?ID=`,
};
