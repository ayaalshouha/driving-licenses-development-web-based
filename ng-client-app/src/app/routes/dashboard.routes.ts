import { Routes } from '@angular/router';
import { TestComponent } from '../dashboard/test/test.component';
import { services_routes } from './services.routes';
import { app_management_routes } from './application-management.routes';
import { licenses_management_routes } from './licenses-management.routes';
import { system_routes } from './system.routes';

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
    path: 'applications-management',
    children: app_management_routes,
  },
  {
    path: 'licenses-management',
    children: licenses_management_routes,
  },
  {
    path: 'appointments',
    children: [],
  },
  {
    path: 'system',
    children: system_routes,
  },
];
