// application-types.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApplicationType } from '../models/application-type.model';
import { APPLICATION_TYPE_API_ENDPOINT } from '../environments/endpoints/application-type.endpoints';

@Injectable({
  providedIn: 'root',
})
export class ApplicationTypesService {
  constructor(private http: HttpClient) {}

  getApplicationTypes(): Observable<ApplicationType[]> {
    return this.http.get<ApplicationType[]>(APPLICATION_TYPE_API_ENDPOINT.all);
  }

  // getApplicationTypeById(id: number): Observable<ApplicationType> {
  //   return this.http.get<ApplicationType>(`${this.apiUrl}/${id}`);
  // }
}
