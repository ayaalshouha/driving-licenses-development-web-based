import { Routes } from '@angular/router';
import { TestComponent } from '../dashboard/test/test.component';
import { services_routes } from './services.routes';
import { app_management_routes } from './applicationManagement.routes';
import { licenses_management_routes } from './licensesManagement.routes';
import { canDeactivate } from '../dashboard/services/new-local-application/new-local-application.component';

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
    canDeactivate: [canDeactivate],
  },
  {
    path: 'applications-management',
    children: app_management_routes,
  },
  {
    path: 'licenses-management',
    children: licenses_management_routes,
  },
];
