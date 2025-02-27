import { environment } from '../environment';

export const LICENSE_API_ENDPOINT = {
  count: `${environment.apiBaseUrl}/license/count`,
  read: `${environment.apiBaseUrl}/license/`,
  isDetained: (ID: number) =>
    `${environment.apiBaseUrl}/license/${ID}/is-detained`,
  detain: (ID: number, fees: number, byUserID: number) =>
    `${environment.apiBaseUrl}/license/${ID}/detain/fees/${fees}/by-user-id/${byUserID}`,
  release: (ID: number, byUserID: number) =>
    `${environment.apiBaseUrl}/license/${ID}/release/by-user-id/${byUserID}`,
  renew: (ID: number, notes: string, byUserID: number) =>
    `${environment.apiBaseUrl}/license/${ID}/renew/by-user-id/${byUserID}?notes=${notes}`,

  lostReplacement: (ID: number, byUserID: number) =>
    `${environment.apiBaseUrl}/license/${ID}/lost-replacement/by-user-id/${byUserID}`,

  damageReplacement: (ID: number, byUserID: number) =>
    `${environment.apiBaseUrl}/license/${ID}/damaged-replacement/by-user-id/${byUserID}`,
};
