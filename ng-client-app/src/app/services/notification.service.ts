import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

type notifyStatus = 'success' | 'failed' | 'notification' | null;

export interface NotificationBox {
  message: string;
  status: notifyStatus;
}

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  private messageBox = new BehaviorSubject<NotificationBox | null>(null);

  messageBox$ = this.messageBox.asObservable();

  showMessage(messageBox: NotificationBox) {
    this.messageBox.next(messageBox);
  }

  hideNotification() {
    this.messageBox.next(null);
  }
}
