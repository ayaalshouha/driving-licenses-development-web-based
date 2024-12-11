import { environment } from '../environment';

export const LOGIN_API_ENDPOINTS = {

  isUserActive: (username: string, password: string) =>
    `${environment.apiBaseUrl}/login/${username}/${password}/is-active`,


  isUsernameExist: (username: string) =>
    `${environment.apiBaseUrl}/login/${username}/is-exist`,

  
  isCorrect: (username: string, password: string) =>
    `${environment.apiBaseUrl}/login/${username}/${password}/is-exist`,
  saveLogin: `${environment.apiBaseUrl}/login/`,
};
