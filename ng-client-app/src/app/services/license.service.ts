import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { LICENSE_API_ENDPOINT } from '../environments/endpoints/license.endpoint';
import { License } from '../models/license.model';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';
import { error } from 'console';
@Injectable({
  providedIn: 'root',
})
export class LicenseService {
  constructor(private http: HttpClient) {}

  read(ID: number): Observable<License> {
    return this.http.get<License>(`${LICENSE_API_ENDPOINT.read}${ID}`).pipe(
      catchError((error) => {
        if (error.status == 404) {
          throwError(() => new Error(`License with ID ${ID} NOT Found`));
        }
        return throwError(() => new Error('An unexpected error occurred.'));
      })
    );
  }
  // getAll(): Observable<License[]> {
  //   // return this.http.get<License[]>(LICENSE_API_ENDPOINT.all);
  // }
}
