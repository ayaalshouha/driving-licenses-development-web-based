import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NewLocalApplicationComponent } from "./dashboard/services/new-local-application/new-local-application.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NewLocalApplicationComponent, DashboardComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'DVLD';
}
