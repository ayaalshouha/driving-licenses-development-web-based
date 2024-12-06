import { Component, inject, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';
import { CanDeactivateFn, Router, RouterOutlet } from '@angular/router';
import { CurrentUserService } from '../services/current-user.service';
import { HeaderComponent } from './header/header.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { NotificationComponent } from '../shared/notification/notification.component';
import { log } from 'console';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    HeaderComponent,
    SidebarComponent,
    RouterOutlet,
    NotificationComponent,
  ],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  private currentUserService = inject(CurrentUserService);
  current_user = this.currentUserService.getCurrentUser();

  constructor(private router: Router) {}

  ngOnInit() {
    console.log(this.currentUserService.getCurrentUser());
    // check local storage if hold credintials
    // const saveditems = window.localStorage.getItem('saved-item');
    // if (saveditems) {
    //   console.log('saved item exist ')
    //   // this.router.navigate(['/login']);
    // }
  }
}

// The error appears in the canDeactivate function.
// If canDeactivate directly references window, it will fail during SSR.
// export const canDeactivate: CanDeactivateFn<DashboardComponent> = (
//   component,
//   currentRoute,
//   currentState,
//   nextState
// ) => {
//   const platformId = inject(PLATFORM_ID);
//   if (isPlatformBrowser(platformId)) {
//     return window.confirm('Are you sure you want to logout?');
//   }
//   return false;
// };
