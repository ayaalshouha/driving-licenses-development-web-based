import { environment } from '../environment';

export const DRIVER_API_ENDPOINT = {
  all: `${environment.apiBaseUrl}/driver/drivers`,
  localActiveLicenses: (driverid: number) =>
    `${environment.apiBaseUrl}/driver/${driverid}/local-active-licenses`,
};
