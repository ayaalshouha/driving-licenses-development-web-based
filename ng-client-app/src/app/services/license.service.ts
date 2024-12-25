import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map, Observable, tap, throwError } from 'rxjs';
import { LICENSE_API_ENDPOINT } from '../environments/endpoints/license.endpoint';
import { License } from '../models/license.model';
@Injectable({
  providedIn: 'root',
})
export class LicenseService {
  constructor(private http: HttpClient) {}
  count(): Observable<number> {
    return this.http.get<number>(LICENSE_API_ENDPOINT.count);
  }
  read(ID: number): Observable<License> {
    return this.http.get<License>(`${LICENSE_API_ENDPOINT.read}${ID}`).pipe(
      catchError((error) => {
        if (error.status == 404) {
          return throwError(() => new Error(`License with ID ${ID} NOT Found`));
        }
        return throwError(() => new Error('An unexpected error occurred.'));
      })
    );
  }

  renew(ID: number, notes: string, byUserID: number): Observable<License> {
    return this.http
      .get<License>(LICENSE_API_ENDPOINT.renew(ID, notes, byUserID), {
        observe: 'body',
      })
      .pipe(
        catchError((error) => {
          if (error.status == 404) {
            return throwError(
              () => new Error(`License with ID ${ID} NOT Found`)
            );
          }
          return throwError(() => new Error('An unexpected error occurred.'));
        }),
        map((response) => {
          return response;
        })
      );
  }

  lostReplacement(ID: number, byUserID: number): Observable<License> {
    return this.http
      .get<License>(LICENSE_API_ENDPOINT.lostReplacement(ID, byUserID), {
        observe: 'body',
      })
      .pipe(
        catchError((error) => {
          if (error.status == 404) {
            return throwError(
              () => new Error(`License with ID ${ID} NOT Found`)
            );
          }
          return throwError(() => new Error('An unexpected error occurred.'));
        }),
        map((response) => {
          return response;
        })
      );
  }

  damageReplacement(ID: number, byUserID: number): Observable<License> {
    return this.http
      .get<License>(LICENSE_API_ENDPOINT.damageReplacement(ID, byUserID), {
        observe: 'body',
      })
      .pipe(
        catchError((error) => {
          if (error.status == 404) {
            return throwError(
              () => new Error(`License with ID ${ID} NOT Found`)
            );
          }
          return throwError(() => new Error('An unexpected error occurred.'));
        }),
        map((response) => {
          return response;
        })
      );
  }

  detain(ID: number, fees: number, byUserID: number): Observable<number> {
    return this.http
      .get<number>(LICENSE_API_ENDPOINT.detain(ID, fees, byUserID), {
        observe: 'body',
      })
      .pipe(
        catchError((error) => {
          if (error.status == 404) {
            return throwError(
              () => new Error(`License with ID ${ID} NOT Found`)
            );
          }
          return throwError(() => new Error('An unexpected error occurred.'));
        }),
        map((response) => {
          return response;
        })
      );
  }
  release(ID: number, byUserID: number): Observable<boolean> {
    return this.http
      .get<boolean>(LICENSE_API_ENDPOINT.release(ID, byUserID), {
        observe: 'body',
      })
      .pipe(
        catchError((error) => {
          if (error.status == 404) {
            return throwError(
              () => new Error(`License with ID ${ID} NOT Found`)
            );
          }
          return throwError(() => new Error('An unexpected error occurred.'));
        }),
        map((response) => {
          return response;
        })
      );
  }

  isDetained(licenseID: number): Observable<boolean> {
    return this.http
      .get<boolean>(LICENSE_API_ENDPOINT.isDetained(licenseID), {
        observe: 'body',
      })
      .pipe(
        catchError((error) => {
          if (error.status == 404) {
            return throwError(
              () => new Error(`License with ID ${licenseID} NOT Found`)
            );
          }
          return throwError(() => new Error('An unexpected error occurred.'));
        }),
        map((response) => {
          return response;
        })
      );
  }
  // getAll(): Observable<License[]> {
  //   // return this.http.get<License[]>(LICENSE_API_ENDPOINT.all);
  // }
}
