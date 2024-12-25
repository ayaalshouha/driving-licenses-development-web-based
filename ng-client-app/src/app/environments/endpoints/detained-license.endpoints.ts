import { read } from 'fs';
import { environment } from '../environment';

export const DETAINED_LICENSE_API_ENDPOINT = {
  read_bu_licenseID: (licenseID: number) =>
    `${environment.apiBaseUrl}/detainedLicense/by-license-id/${licenseID}`,
  all: `${environment.apiBaseUrl}/detainedLicense/detained-licenses`,
};
