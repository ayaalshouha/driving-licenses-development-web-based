import { Component, signal } from '@angular/core';
import {
  NotificationBox,
  NotificationService,
} from '../../services/notification.service';
@Component({
  selector: 'app-notification',
  standalone: true,
  imports: [],
  templateUrl: './notification.component.html',
  styleUrl: './notification.component.css',
})
export class NotificationComponent {
  messageBox = signal<NotificationBox | null>(null);

  constructor(private notificationService: NotificationService) {
    this.notificationService.messageBox$.subscribe((messageBoxServ) =>
      this.messageBox.set(messageBoxServ)
    );
  }

  closeNotification() {
    this.notificationService.hideNotification();
  }
}
