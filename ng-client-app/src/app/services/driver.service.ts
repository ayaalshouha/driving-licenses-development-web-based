import { Injectable } from '@angular/core';
import { DRIVER_API_ENDPOINT } from '../environments/endpoints/driver.endpoints';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { Driver_View } from '../models/driver.model';
import { ShortLicense } from '../models/license.model';
import { ShortInternationalLicense } from '../models/internationl-license.model';
@Injectable({
  providedIn: 'root',
})
export class DriverService {
  constructor(private http: HttpClient) {}
  read(ID: number): Observable<Driver_View> {
    return this.http.get<Driver_View>(DRIVER_API_ENDPOINT.read_view(ID)).pipe(
      catchError((error) => {
        if (error.status == 404) {
          return throwError(() => new Error(`Driver with ID ${ID} NOT Found`));
        }
        return throwError(() => new Error(`something error happened`));
      })
    );
  }
  getAll(): Observable<Driver_View[]> {
    return this.http.get<Driver_View[]>(DRIVER_API_ENDPOINT.all);
  }
  count(): Observable<number> {
    return this.http.get<number>(DRIVER_API_ENDPOINT.count);
  }

  localLicenses(driverid: number): Observable<ShortLicense[]> {
    return this.http.get<ShortLicense[]>(
      DRIVER_API_ENDPOINT.localLicenses(driverid)
    );
  }

  internationalLicenses(
    driverid: number
  ): Observable<ShortInternationalLicense[]> {
    return this.http.get<ShortInternationalLicense[]>(
      DRIVER_API_ENDPOINT.internationalLicenses(driverid)
    );
  }
}
