import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map, Observable, tap, throwError } from 'rxjs';
import { Test } from '../models/test.model';
import { TESTS_API_ENDPOINTS } from '../environments/endpoints/test.endpoints';

@Injectable({
  providedIn: 'root',
})
export class TestService {
  constructor(private http: HttpClient) {}
  create(new_test: Test): Observable<Test> {
    return this.http.post<Test>(TESTS_API_ENDPOINTS.add, new_test).pipe(
      catchError((error) => throwError(() => new Error(error.message))),
      map((response) => {
        return response;
      })
    );
  }
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
