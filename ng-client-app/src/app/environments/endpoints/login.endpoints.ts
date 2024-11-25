import { environment } from '../environment';

export const LOGIN_API_ENDPOINTS = {
  isUsernameExist: `${environment.apiBaseUrl}/Login/isExistByUsername?username=`,
  isCorrect: `${environment.apiBaseUrl}/Login/isExist`,
  isUserActive: `${environment.apiBaseUrl}/Login/isActive`,
  saveLogin: `${environment.apiBaseUrl}/Login/Create?UserID=`,
};