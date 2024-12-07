import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PERSON_API_ENDPOINTS } from '../environments/endpoints/person.endpoints';
import { catchError, map, Observable, tap, throwError } from 'rxjs';
import { Person } from '../models/person.model';
@Injectable({
  providedIn: 'root',
})
export class PersonService {
  constructor(private http: HttpClient) {}

  readUser(ID: number) {}

  isNationalNoExist(national_no: string): Observable<boolean> {
    return this.http.get<boolean>(
      `${PERSON_API_ENDPOINTS.isExistByNationalNo}${national_no}`
    );
  }

  create(new_person: Person): Observable<Person> {
    return this.http.post<Person>(PERSON_API_ENDPOINTS.create, new_person);
  }
}
