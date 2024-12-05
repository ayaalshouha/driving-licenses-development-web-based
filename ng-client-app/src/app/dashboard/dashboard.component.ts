import { Component, inject, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';
import { CanDeactivateFn, Router, RouterOutlet } from '@angular/router';
import { CurrentUserService } from '../services/current-user.service';
import { HeaderComponent } from './header/header.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { PLATFORM_ID, Inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [HeaderComponent, SidebarComponent, RouterOutlet],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
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

// The error appears in the canDeactivate function.
// If canDeactivate directly references window, it will fail during SSR.
export const canDeactivate: CanDeactivateFn<DashboardComponent> = (
  component,
  currentRoute,
  currentState,
  nextState
) => {
  const platformId = inject(PLATFORM_ID);
  if (isPlatformBrowser(platformId)) {
    return window.confirm(
      'Are you sure you want to leave? Unsaved changes will be lost.'
    );
  }
  return false;
};
