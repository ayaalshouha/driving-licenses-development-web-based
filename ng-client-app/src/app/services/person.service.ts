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

  isNationalNoExist(national_no: string): Observable<boolean> {
    return this.http.get<boolean>(
      `${PERSON_API_ENDPOINTS.isExistNationalNo(national_no)}`
    );
  }

  create(new_person: Person): Observable<Person> {
    return this.http.post<Person>(PERSON_API_ENDPOINTS.create, new_person);
  }

  read(ID: number): Observable<Person> {
    return this.http.get<Person>(`${PERSON_API_ENDPOINTS.read}${ID}`);
  }

  getFullName(ID: number): Observable<string> {
    return this.http.get<string>(`${PERSON_API_ENDPOINTS.fullName(ID)}`);
  }
}
