import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  private message = signal<string | null>(null);

  showMessage(msg: string) {
    this.message.set(msg);
    setTimeout(() => this.message.set(null), 3000); // Clear after 3 seconds
  }

  getMessage() {
    return this.message;
  }
}
