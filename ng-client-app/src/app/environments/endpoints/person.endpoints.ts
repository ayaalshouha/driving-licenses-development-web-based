import { environment } from '../environment';
export const PERSON_API_ENDPOINTS = {
  all: `${environment.apiBaseUrl}/Person/All`,
  read: `${environment.apiBaseUrl}/Person/Read?ID=`,
  create: `${environment.apiBaseUrl}/Person/Create`,
  update: `${environment.apiBaseUrl}/Person/Update?ID=`,
  delete: `${environment.apiBaseUrl}/Person/Delete?ID=`,
  isExist: `${environment.apiBaseUrl}/Person/isExistByID?ID=`,
  isExistByNationalNo: `${environment.apiBaseUrl}/Person/isExistByNationalNo?NationalNumber=`,
};
