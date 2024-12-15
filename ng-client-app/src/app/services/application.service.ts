import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Application } from '../models/application.model';
import { APPLICATION_API_ENDPOINT } from '../environments/endpoints/application.endpoints';
import { map, Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ApplicationService {
  constructor(private http: HttpClient) {}

  create(new_application: Application): Observable<Application> {
    return this.http
      .post<Application>(APPLICATION_API_ENDPOINT.create, new_application)
      .pipe(
        map((res) => {
          return res;
        })
      );
  }
  read(ID: number): Observable<Application> {
    return this.http
      .get<Application>(`${APPLICATION_API_ENDPOINT.read}${ID}`)
      .pipe(tap((res) => console.log('this is returned main app ' + res)));
  }
}
