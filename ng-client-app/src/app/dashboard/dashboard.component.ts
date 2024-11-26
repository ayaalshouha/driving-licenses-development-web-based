import { Component, inject, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';
import { Router } from '@angular/router';
import { CurrentUserService } from '../services/current-user.service';
import { HeaderComponent } from './header/header.component';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [HeaderComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
})
export class DashboardComponent implements OnInit {
  private currentUserService = inject(CurrentUserService);
  current_user = this.currentUserService.getCurrentUser();

  constructor(private loginService: LoginService, private router: Router) {}

  ngOnInit() {
    this.loginService.getLoginStatue().subscribe((loggedIn) => {
      console.log(loggedIn);
      if (!loggedIn) {
        this.router.navigate(['/login']);
      }
    });
  }
}
