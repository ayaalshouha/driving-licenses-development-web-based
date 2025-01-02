import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
  LocalApplication,
  LocalApplicationView,
} from '../models/local-application.model';
import { LOCAL_APPLICATION_API_ENDPOINT } from '../environments/endpoints/local-application.endpoints';
import { catchError, map, Observable, tap, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class LocalApplicationService {
  constructor(private http: HttpClient) {}

  create(new_application: LocalApplication): Observable<LocalApplication> {
    return this.http.post<LocalApplication>(
      LOCAL_APPLICATION_API_ENDPOINT.create,
      new_application
    );
  }

  getAll(): Observable<LocalApplicationView[]> {
    return this.http.get<LocalApplicationView[]>(
      LOCAL_APPLICATION_API_ENDPOINT.all
    );
  }

  read(ID: number): Observable<LocalApplication> {
    return this.http
      .get<LocalApplication>(`${LOCAL_APPLICATION_API_ENDPOINT.read}${ID}`)
      .pipe(
        catchError((error) => {
          if (error.status === 404) {
            // Emit a specific error message for 404
            return throwError(
              () => new Error(`Application with ID ${ID} NOT Found`)
            );
          }
          // Handle other errors
          return throwError(() => new Error('An unexpected error occurred.'));
        })
      );
  }
  readView(ID: number): Observable<LocalApplicationView> {
    return this.http
      .get<LocalApplicationView>(LOCAL_APPLICATION_API_ENDPOINT.readView(ID))
      .pipe(
        catchError((error) => {
          if (error.status === 404) {
            // Emit a specific error message for 404
            return throwError(
              () => new Error(`Application with ID ${ID} NOT Found`)
            );
          }
          // Handle other errors
          return throwError(() => new Error('An unexpected error occurred.'));
        }),
        map((response) => {
          return response;
        })
      );
  }

  passedTestCount(id: number): Observable<number> {
    return this.http.get<number>(
      LOCAL_APPLICATION_API_ENDPOINT.passedTestCount(id)
    );
  }

  isLicenseIssued(id: number): Observable<boolean> {
    return this.http
      .get<boolean>(LOCAL_APPLICATION_API_ENDPOINT.isLicenseIssued(id))
      .pipe(
        catchError((error) => {
          return throwError(() => new Error(error));
        })
      );
  }
  isTestAttended(id: number, testID: number): Observable<boolean> {
    return this.http.get<boolean>(
      LOCAL_APPLICATION_API_ENDPOINT.isTestAttended(id, testID)
    );
  }

  cancel(id: number): Observable<boolean> {
    return this.http
      .patch<boolean>(LOCAL_APPLICATION_API_ENDPOINT.cancel(id), {})
      .pipe(
        catchError((error) => {
          return throwError(() => new Error(error));
        })
      );
  }

  issueLicenseFisrTime(
    id: number,
    userid: number,
    notes: string | null
  ): Observable<number> {
    return this.http
      .get<number>(
        LOCAL_APPLICATION_API_ENDPOINT.issueLicense(id, notes, userid)
      )
      .pipe(
        catchError((error) => {
          return throwError(() => new Error(error.message));
        })
      );
  }

  licenseID(id: number): Observable<number> {
    return this.http
      .get<number>(LOCAL_APPLICATION_API_ENDPOINT.licenseID(id))
      .pipe(
        catchError((error) => {
          return throwError(() => new Error(error.message));
        })
      );
  }
}
