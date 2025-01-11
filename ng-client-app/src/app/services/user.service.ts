import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { USER_API_ENDPOINTS } from '../environments/endpoints/user.endpoints';
import { User } from '../models/user.model';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private httpClient: HttpClient) {}
  all(): Observable<User[]> {
    return this.httpClient.get<User[]>(USER_API_ENDPOINTS.all).pipe(
      catchError((error) => {
        return throwError(() => new Error(error.message));
      })
    );
  }
  readUser(username: string) {
    return this.httpClient.get<User>(
      `${USER_API_ENDPOINTS.readByUsername}${username}`
    );
  }
}
