import { Inject, Injectable, PLATFORM_ID } from '@angular/core';
import { User } from '../models/user.model';
import { isPlatformBrowser } from '@angular/common';

@Injectable({
  providedIn: 'root',
})
export class CurrentUserService {
  private current_user: User | undefined = undefined;

  constructor(@Inject(PLATFORM_ID) private platformId: Object) {}

  setCurrentUser(user: User) {
    this.current_user = user;
  }
  getCurrentUser(): User | undefined {
    if (isPlatformBrowser(this.platformId)) {
      const saved_user = window.localStorage.getItem('current-user');
      if (saved_user) {
        this.setCurrentUser(JSON.parse(saved_user));
        return this.current_user;
      }
    }
    return undefined;
  }

  clearCurrentUser() {
    if (isPlatformBrowser(this.platformId)) {
      window.localStorage.removeItem('current-user');
    }
  }
}
