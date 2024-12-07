import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  private notification = new BehaviorSubject<string | null>(null);
  notification$ = this.notification.asObservable();

  showMessage(message: string) {
    this.notification.next(message);
  }

  hideNotification() {
    this.notification.next(null);
  }
}
