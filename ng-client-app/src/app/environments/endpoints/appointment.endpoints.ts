import { environment } from '../environment';

export const APPOINTMENT_API_ENDPOINT = {
  readView: (id: number) =>
    `${environment.apiBaseUrl}/appointment/appointment-view/${id}`,
  all: `${environment.apiBaseUrl}/appointment/appointments-view`,
  add: `${environment.apiBaseUrl}/appointment`,
  read: (test_type: number, local_app: number) =>
    `${environment.apiBaseUrl}/appointment/test-type/${test_type}/local-app/${local_app}`,
  active_appointments: (test_type: number, local_app: number) =>
    `${environment.apiBaseUrl}/appointment/active-appointments-exist/by-test-type/${test_type}/local-app/${local_app}`,
  updateDate: (id: number, new_date: string) =>
    `${environment.apiBaseUrl}/appointment/${id}/update-date/${new_date}`,
};
