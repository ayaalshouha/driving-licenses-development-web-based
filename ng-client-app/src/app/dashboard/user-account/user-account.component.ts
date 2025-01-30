import { Component } from '@angular/core';
import { NewLocalApplicationComponent } from '../services/new-local-application/new-local-application.component';

@Component({
  selector: 'app-user-account',
  standalone: true,
  imports: [NewLocalApplicationComponent],
  templateUrl: './user-account.component.html',
  styleUrl: './user-account.component.css',
})
export class UserAccountComponent {}
