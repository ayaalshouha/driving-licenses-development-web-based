import { Routes } from '@angular/router';
import { TestComponent } from '../dashboard/test/test.component';
import { services_routes } from './services.routes';
import { app_management_routes } from './applicationManagement.routes';
import { licenses_management_routes } from './licensesManagement.routes';

export const dashboard_routes: Routes = [
  {
    path: '',
    redirectTo: 'test',
    pathMatch: 'full',
  },
  {
    path: 'test',
    component: TestComponent,
  },
  {
    path: 'services',
    children: services_routes,
  },
  {
    path: 'applicationsManagement',
    children: app_management_routes,
  },
  {
    path: 'licensesManagement',
    children: licenses_management_routes,
  },
];

// {
//   path: 'people',
//   component: DashboardComponent,
// },
// {
//   path: 'users',
//   component: DashboardComponent,
// },
// {
//   path: 'settings',
//   component: DashboardComponent,
// },
