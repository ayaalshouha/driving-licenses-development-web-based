import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DETAINED_LICENSE_API_ENDPOINT } from '../environments/endpoints/detained-license.endpoints';
import { DetainedLicense } from '../models/detained-license.model';
import { catchError, Observable, throwError } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class DetainedLicenseService {
  constructor(private http: HttpClient) {}

  read(LicenceID: number): Observable<DetainedLicense> {
    return this.http
      .get<DetainedLicense>(
        DETAINED_LICENSE_API_ENDPOINT.read_bu_licenseID(LicenceID),
        {
          observe: 'body',
        }
      )
      .pipe(
        catchError((error) => {
          if (error.status == 404) {
            return throwError(
              () => new Error(`Detaied license with ID ${LicenceID} NOT found`)
            );
          }
          return throwError(() => new Error('An unexpected error happened'));
        })
      );
  }
  all(): Observable<DetainedLicense[]> {
    return this.http.get<DetainedLicense[]>(DETAINED_LICENSE_API_ENDPOINT.all);
  }
}
