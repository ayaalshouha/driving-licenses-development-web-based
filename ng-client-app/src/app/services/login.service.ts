import { Injectable } from '@angular/core';
import { LOGIN_API_ENDPOINTS } from '../environments/endpoints/login.endpoints';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BehaviorSubject, catchError, map, Observable, of, tap } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(private httpClient: HttpClient) {}

  //check if entered username is unique for firsttime register
  isExist(username: string): Observable<boolean> {
    return (
      this.httpClient
        .get<{ exist: boolean }>(LOGIN_API_ENDPOINTS.isUsernameExist(username))
        // Return true if the username exists
        .pipe(map((response) => response.exist))
    );
  }

  //check if username and passowrd BOTH match database
  isCorrect(username: string, password: string): Observable<boolean> {
    return this.httpClient.get<boolean>(
      `${LOGIN_API_ENDPOINTS.isCorrect(username, password)}`
    );
  }

  //check if entered user is active
  isActive(username: string, password: string): Observable<boolean> {
    return this.httpClient.get<boolean>(
      `${LOGIN_API_ENDPOINTS.isUserActive(username, password)}`
    );
  }
  //save login record in database
  saveLogin(userID: number) {
    return this.httpClient.post(
      `${LOGIN_API_ENDPOINTS.saveLogin}${userID}`,
      {}
    );
  }
}
