import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor() {}

  //check if entered username is exist
  isExist() {}

  //check if entered user is active
  isActive() {}
  //check if login record saved in database
  isLoginSaved() {}
}
