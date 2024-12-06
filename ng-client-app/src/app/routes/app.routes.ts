import { Routes } from '@angular/router';
import { LoginComponent } from '../login/login.component';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { dashboard_routes } from './dashboard.routes';
// import { canDeactivate } from '../dashboard/dashboard.component';
export const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full',
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
    children: dashboard_routes,
    // canDeactivate: [canDeactivate],
  },
];
