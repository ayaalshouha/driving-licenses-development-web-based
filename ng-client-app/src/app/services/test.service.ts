import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Test } from '../models/test.model';
import { TESTS_API_ENDPOINTS } from '../environments/endpoints/test.endpoints';

@Injectable({
  providedIn: 'root',
})
export class TestService {
  constructor(private http: HttpClient) {}

  all(): Observable<Test[]> {
    return this.http.get<Test[]>(TESTS_API_ENDPOINTS.all);
  }

  count(): Observable<number> {
    return this.http.get<number>(TESTS_API_ENDPOINTS.count);
  }

  // getFees(type_id: number) {
  //   return this.http.get<Observable<number>>(TEST_TYPE_API_ENDPOINT.fee(type_id));
  // }

  // getApplicationTypeById(id: number): Observable<ApplicationType> {
  //   return this.http.get<ApplicationType>(`${this.apiUrl}/${id}`);
  // }
}
