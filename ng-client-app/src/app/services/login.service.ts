import { DestroyRef, inject, Injectable } from '@angular/core';
import { LOGIN_API_ENDPOINTS } from '../environments/endpoints/login.endpoints';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { response } from 'express';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';
@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(private httpClient: HttpClient) {}

  //check if entered username is exist
  isExist(username: string): Observable<boolean> {
    return this.httpClient
      .get<boolean>(`${LOGIN_API_ENDPOINTS.isUsernameExist}${username}`)
      .pipe(tap((response) => console.log('User existence = ' + response)));
  }

  //check if username and passowrd BOTH match database
  isCorrect(username: string, password: string): Observable<boolean> {
    const params = new HttpParams()
      .set('username', username)
      .set('password', password);

    return this.httpClient
      .get<boolean>(`${LOGIN_API_ENDPOINTS.isCorrect}`, { params })
      .pipe(tap((response) => console.log('does user auths correct = ' + response)));
  }

  //check if entered user is active
  isActive(username: string, password: string): Observable<boolean> {
    const params = new HttpParams()
      .set('username', username)
      .set('password', password);

    return this.httpClient
      .get<boolean>(`${LOGIN_API_ENDPOINTS.isUserActive}`, { params })
      .pipe(tap((response) => console.log('User Activeness = ' + response)));
  }
  //check if login record saved in database
  isLoginSaved() {}
}
