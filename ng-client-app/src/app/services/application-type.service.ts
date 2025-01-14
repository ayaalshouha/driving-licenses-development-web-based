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
  add(new_application: ApplicationType): Observable<ApplicationType> {
    return this.http
      .post<ApplicationType>(APPLICATION_TYPE_API_ENDPOINT.add, new_application)
      .pipe(
        catchError((error) => {
          return throwError(() => new Error(error.messages));
        })
      );
  }
  all(): Observable<ApplicationType[]> {
    return this.http.get<ApplicationType[]>(APPLICATION_TYPE_API_ENDPOINT.all);
  }
  // getFees(type_id: number) {
  //   return this.http.get<Observable<number>>(
  //     `${APPLICATION_TYPE_API_ENDPOINT.fees}${type_id}`
  //   );
  // }

  // getApplicationTypeById(id: number): Observable<ApplicationType> {
  //   return this.http.get<ApplicationType>(`${this.apiUrl}/${id}`);
  // }
}
