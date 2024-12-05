import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LocalApplication } from '../models/local-application.model';
import { LOCAL_APPLICATION_API_ENDPOINT } from '../environments/endpoints/local-application.endpoints';
import { map, Observable } from 'rxjs';

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
}
