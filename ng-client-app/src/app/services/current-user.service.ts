import { Injectable, signal } from '@angular/core';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class CurrentUserService {
  private current_user = signal<User | undefined>(undefined);

  setCurrentUser(status: User | undefined) {
    this.current_user.set(status);
  }

  getCurrentUser() {
    return this.current_user();
  }
}
