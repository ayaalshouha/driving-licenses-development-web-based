import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { ApplicationType } from '../models/application-type.model';
import { APPLICATION_TYPE_API_ENDPOINT } from '../environments/endpoints/application-type.endpoints';

@Injectable({
  providedIn: 'root',
})
export class ApplicationTypesService {
  constructor(private http: HttpClient) {}

  get(id: number): Observable<ApplicationType> {
    return this.http
      .get<ApplicationType>(`${APPLICATION_TYPE_API_ENDPOINT.read}${id}`)
      .pipe(
        catchError((error) => {
          return throwError(() => new Error(error.messages));
        })
      );
  }

  add(new_application: ApplicationType): Observable<ApplicationType> {
    return this.http
      .post<ApplicationType>(APPLICATION_TYPE_API_ENDPOINT.add, new_application)
      .pipe(
        catchError((error) => {
          return throwError(() => new Error(error.messages));
        })
      );
  }
  update(
    id: number,
    updated_type: ApplicationType
  ): Observable<ApplicationType> {
    return this.http
      .put<ApplicationType>(
        `${APPLICATION_TYPE_API_ENDPOINT.update}${id}`,
        updated_type
      )
      .pipe(
        catchError((error) => {
          return throwError(() => new Error(error.messages));
        })
      );
  }

  all(): Observable<ApplicationType[]> {
    return this.http.get<ApplicationType[]>(APPLICATION_TYPE_API_ENDPOINT.all);
  }
  delete(id: number) {
    return this.http
      .delete(`${APPLICATION_TYPE_API_ENDPOINT.delete}${id}`)
      .pipe(
        catchError((error) => {
          return throwError(() => new Error(error.messages));
        })
      );
  }
}
