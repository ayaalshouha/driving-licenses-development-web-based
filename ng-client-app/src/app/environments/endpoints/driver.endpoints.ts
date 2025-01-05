import { environment } from '../environment';

export const DRIVER_API_ENDPOINT = {
  all: `${environment.apiBaseUrl}/driver/drivers`,
  localLicenses: (driverid: number) =>
    `${environment.apiBaseUrl}/driver/${driverid}/local-licenses`,
  read: `${environment.apiBaseUrl}/driver/`,
  read_view: (driverid: number) =>
    `${environment.apiBaseUrl}/driver/${driverid}/driver-view`,
  count: `${environment.apiBaseUrl}/driver/count`,
  internationalLicenses: (driverid: number) =>
    `${environment.apiBaseUrl}/driver/${driverid}/international-licenses`,
};
