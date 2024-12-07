import { environment } from '../environment';

export const LICENSE_CLASS_API_ENDPOINT = {
  read: `${environment.apiBaseUrl}/LicenseClass/Read?classID=`,
  allClasses: `${environment.apiBaseUrl}/LicenseClass/All`,
};
