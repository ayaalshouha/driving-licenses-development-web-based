import { Injectable, signal } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  private notification = new BehaviorSubject<string | null>(null);
  notification$ = this.notification.asObservable();

  showMessage(message: string, duration: number = 3000) {
    this.notification.next(message);
    setTimeout(() => this.notification.next(null), duration); // Clear after 3 seconds
  }
}
