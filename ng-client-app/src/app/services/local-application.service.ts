import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
  LocalApplication,
  LocalApplicationView,
} from '../models/local-application.model';
import { LOCAL_APPLICATION_API_ENDPOINT } from '../environments/endpoints/local-application.endpoints';
import { Observable, tap } from 'rxjs';

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
    return this.http.get<LocalApplication>(
      `${LOCAL_APPLICATION_API_ENDPOINT.read}${ID}`
    );
  }

  passedTestCount(id: number): Observable<number> {
    return this.http.get<number>(
      LOCAL_APPLICATION_API_ENDPOINT.passedTestCount(id)
    );
  }

  isTestAttended(id: number, testID: number): Observable<boolean> {
    return this.http.get<boolean>(
      LOCAL_APPLICATION_API_ENDPOINT.isTestAttended(id, testID)
    );
  }
}
