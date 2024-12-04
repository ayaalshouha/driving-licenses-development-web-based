import { environment } from '../environment';
export const PERSON_API_ENDPOINTS = {
  all: `${environment.apiBaseUrl}/Person/All`,
  read: `${environment.apiBaseUrl}/Person/Read?ID=`,
  create: `${environment.apiBaseUrl}/Person/Create`,
  
};
