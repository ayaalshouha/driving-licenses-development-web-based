import { Routes } from '@angular/router';
import { DashboardComponent } from '../dashboard/dashboard.component';

export const dashboard_routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full',
  },
  {
    path: 'people',
    component: DashboardComponent,
  },
  {
    path: 'users',
    component: DashboardComponent,
  },
  {
    path: 'settings',
    component: DashboardComponent,
  },
];
