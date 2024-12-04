import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PERSON_API_ENDPOINTS } from '../environments/endpoints/person.endpoints';
import { Observable, tap } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class PersonService {
  constructor(private http: HttpClient) {}

  readUser(ID: number) {}

  isNationalNoExist(national_no: string): Observable<boolean> {
    return this.http
      .get<boolean>(`${PERSON_API_ENDPOINTS.isExistByNationalNo}${national_no}`)
      .pipe(tap((res) => console.log(res)));
  }
}
