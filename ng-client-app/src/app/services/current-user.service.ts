import { Injectable, signal } from '@angular/core';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class CurrentUserService {
  private current_user = signal<User | undefined>(undefined);

  constructor() {
    const saved_user = window.localStorage.getItem('current-user');
    if (saved_user) {
      this.current_user.set(JSON.parse(saved_user));
    }
  }

  clearCurrentUser() {
    localStorage.removeItem('current-user');
    this.current_user.set(undefined);
  }

  get CurrentUser() {
    return this.current_user();
  }
}
