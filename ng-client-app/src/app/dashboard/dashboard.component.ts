import { Component, inject, OnInit, signal } from '@angular/core';
import { LoginService } from '../services/login.service';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { CurrentUserService } from '../services/current-user.service';
import { User } from '../models/user.model';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
})
export class DashboardComponent implements OnInit {
  private currentUserService = inject(CurrentUserService);
  current_user = this.currentUserService.getCurrentUser();

  constructor(private loginService: LoginService, private router: Router) {}

  ngOnInit() {
    this.loginService.getLoginStatue().subscribe((loggedIn) => {
      if (!loggedIn) {
        this.router.navigate(['/login']);
      }
    });
  }
}
