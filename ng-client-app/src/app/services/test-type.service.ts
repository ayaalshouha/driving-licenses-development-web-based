import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { TEST_TYPE_API_ENDPOINT } from '../environments/endpoints/test-type.endpoints';
import { TestType } from '../models/test-type.model';

@Injectable({
  providedIn: 'root',
})
export class TestTypesService {
  constructor(private http: HttpClient) {}

  all(): Observable<TestType[]> {
    return this.http.get<TestType[]>(TEST_TYPE_API_ENDPOINT.all);
  }
  getFees(type_id: number) {
    return this.http.get<Observable<number>>(TEST_TYPE_API_ENDPOINT.fee(type_id));
  }

  // getApplicationTypeById(id: number): Observable<ApplicationType> {
  //   return this.http.get<ApplicationType>(`${this.apiUrl}/${id}`);
  // }
}
