import { environment } from '../environment';

export const APPOINTMENT_API_ENDPOINT = {
  add: `${environment.apiBaseUrl}/appointment`,
  all: `${environment.apiBaseUrl}/appointment/appointments-view`,
  active_appointments: (test_type: number, local_app: number) =>
    `${environment.apiBaseUrl}/appointment/active-appointments-exist/by-test-type/${test_type}/local-app/${local_app}`,
};
