import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-notification-component',
  standalone: true,
  imports: [],
  templateUrl: './notification.component.html',
  styleUrl: './notification.component.css',
})
export class NotificationComponent {
  message = signal<string | null>(null);

  showMessage(msg: string) {
    this.message.set(msg);
    setTimeout(() => this.message.set(null), 3000); // Hide after 3 seconds
  }
}
