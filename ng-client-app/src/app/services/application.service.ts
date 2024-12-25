import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Application } from '../models/application.model';
import { APPLICATION_API_ENDPOINT } from '../environments/endpoints/application.endpoints';
import { catchError, Observable, tap, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ApplicationService {
  constructor(private http: HttpClient) {}

  create(new_application: Application): Observable<Application> {
    return this.http.post<Application>(
      APPLICATION_API_ENDPOINT.create,
      new_application
    );
  }
  read(ID: number): Observable<Application> {
    return this.http
      .get<Application>(`${APPLICATION_API_ENDPOINT.read}${ID}`)
      .pipe(
        catchError((error) => {
          if (error.status == 404) {
            throwError(() => new Error(`Application with ID ${ID} NOT Found`));
          }
          return throwError(() => new Error('An unexpected error occurred.'));
        })
      );
  }
  count(): Observable<number> {
    return this.http.get<number>(APPLICATION_API_ENDPOINT.count);
  }
}
