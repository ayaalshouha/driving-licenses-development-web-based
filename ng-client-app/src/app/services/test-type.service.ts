import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { TEST_TYPE_API_ENDPOINT } from '../environments/endpoints/test-type.endpoints';
import { TestType } from '../models/test-type.model';

@Injectable({
  providedIn: 'root',
})
export class TestTypesService {
  constructor(private http: HttpClient) {}

  add(new_test: TestType): Observable<TestType> {
    return this.http.post<TestType>(TEST_TYPE_API_ENDPOINT.add, new_test).pipe(
      catchError((error) => {
        return throwError(() => new Error(error.messages));
      })
    );
  }
  all(): Observable<TestType[]> {
    return this.http.get<TestType[]>(TEST_TYPE_API_ENDPOINT.all);
  }
  getFees(type_id: number) {
    return this.http.get<Observable<number>>(
      TEST_TYPE_API_ENDPOINT.fee(type_id)
    );
  }

  delete(id: number) {
    return this.http.delete(`${TEST_TYPE_API_ENDPOINT.delete}${id}`).pipe(
      catchError((error) => {
        return throwError(() => new Error(error.messages));
      })
    );
  }
}
