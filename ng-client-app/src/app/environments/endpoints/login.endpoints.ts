import { environment } from '../environment';

export const LOGIN_API_ENDPOINTS = {
  isUsernameExist: `${environment.apiBaseUrl}/Login/isExistByUsername?username=`,
  isUserActive: `${environment.apiBaseUrl}/Login/isActive?username=&password=`,
  saveLogin: `${environment.apiBaseUrl}/Login/Create?UserID=`,
};
