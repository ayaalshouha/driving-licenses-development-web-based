import { Injectable, signal } from '@angular/core';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class CurrentUserService {
  private current_user = signal<User | undefined>(undefined);

  constructor() {
    const current_user = window.localStorage.getItem('current-user');
    current_user
      ? this.current_user.set(JSON.parse(current_user))
      : this.current_user.set(undefined);
  }

  getCurrentUser() {
    return this.current_user();
  }
}
