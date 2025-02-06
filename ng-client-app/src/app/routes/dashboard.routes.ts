import { Routes } from '@angular/router';
import { TestComponent } from '../dashboard/test/test.component';

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
    path: 'user-account',
    loadChildren: () =>
      import('./user-account.routes').then((mod) => mod.user_account_routes),
  },
  {
    path: 'services',
    loadChildren: () =>
      import('./services.routes').then((mod) => mod.services_routes),
  },
  {
    path: 'manage-tests',
    loadChildren: () =>
      import('./tests-management.route').then(
        (mod) => mod.test_management_routes
      ),
  },
  {
    path: 'applications-management',
    loadChildren: () =>
      import('./application-management.routes').then(
        (mod) => mod.app_management_routes
      ),
  },
  {
    path: 'licenses-management',
    loadChildren: () =>
      import('./licenses-management.routes').then(
        (mod) => mod.licenses_management_routes
      ),
  },
  {
    path: 'appointments',
    loadChildren: () =>
      import('./appointments.routes').then((mod) => mod.appointments_routes),
  },
  {
    path: 'system',
    loadChildren: () =>
      import('./system.routes').then((mod) => mod.system_routes),
  },
  {
    path: 'accounts',
    loadComponent: () =>
      import('../dashboard/accounts/accounts.component').then(
        (module) => module.AccountsComponent
      ),
  },
];
