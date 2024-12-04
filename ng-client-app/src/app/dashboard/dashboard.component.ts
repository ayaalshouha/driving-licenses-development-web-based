import { Component, inject, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';
import { CanDeactivateFn, Router, RouterOutlet } from '@angular/router';
import { CurrentUserService } from '../services/current-user.service';
import { HeaderComponent } from './header/header.component';
import { SidebarComponent } from './sidebar/sidebar.component';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [HeaderComponent, SidebarComponent, RouterOutlet],
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

export const canDeactivate: CanDeactivateFn<DashboardComponent> = (
  component
) => {
  return window.confirm('Are you sure you want to logout?');
};
