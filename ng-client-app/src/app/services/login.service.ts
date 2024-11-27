import { Injectable } from '@angular/core';
import { LOGIN_API_ENDPOINTS } from '../environments/endpoints/login.endpoints';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BehaviorSubject, catchError, map, Observable, of, tap } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(private httpClient: HttpClient) {}

  private loggedIn = new BehaviorSubject<boolean>(true);

  setLoginStatus(status: boolean) {
    this.loggedIn.next(status);
  }

  getLoginStatue() {
    return this.loggedIn.asObservable();
  }
  //check if entered username is unique for firsttime register
  isExist(username: string): Observable<boolean> {
    return (
      this.httpClient
        .get<{ exist: boolean }>(
          `${LOGIN_API_ENDPOINTS.isUsernameExist}${username}`
        )
        // Return true if the username exists
        .pipe(map((response) => response.exist))
    );
  }

  //check if username and passowrd BOTH match database
  isCorrect(username: string, password: string): Observable<boolean> {
    const params = new HttpParams()
      .set('username', username)
      .set('password', password);

    return this.httpClient.get<boolean>(`${LOGIN_API_ENDPOINTS.isCorrect}`, {
      params,
    });
  }

  //check if entered user is active
  isActive(username: string, password: string): Observable<boolean> {
    const params = new HttpParams()
      .set('username', username)
      .set('password', password);

    return this.httpClient.get<boolean>(`${LOGIN_API_ENDPOINTS.isUserActive}`, {
      params,
    });
  }
  //save login record in database
  saveLogin(userID: number) {
    return this.httpClient.post(
      `${LOGIN_API_ENDPOINTS.saveLogin}${userID}`,
      {}
    );
  }
}
