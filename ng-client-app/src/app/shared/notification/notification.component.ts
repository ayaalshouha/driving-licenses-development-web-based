import { Component, signal } from '@angular/core';
import { NotificationService } from '../../services/notification.service';

@Component({
  selector: 'app-notification',
  standalone: true,
  imports: [],
  templateUrl: './notification.component.html',
  styleUrl: './notification.component.css',
})
export class NotificationComponent {
  message = signal<string | null>(null);

  constructor(private notificationService: NotificationService) {
    this.notificationService.notification$.subscribe((msg) =>
      this.message.set(msg)
    );
  }
}
