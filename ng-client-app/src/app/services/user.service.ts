import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { USER_API_ENDPOINTS } from '../environments/endpoints/user.endpoints';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private httpClient: HttpClient) {}

  getUser(username: string) {
    return this.httpClient.get<User>(
      `${USER_API_ENDPOINTS.readUserByUsername}${username}`
    );
  }
}
