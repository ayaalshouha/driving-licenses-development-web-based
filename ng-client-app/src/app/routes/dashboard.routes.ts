import { Routes } from '@angular/router';
import { TestComponent } from '../dashboard/test/test.component';
import { ServicesComponent } from '../dashboard/services/services.component';
import { ApplicationsManagementComponent } from '../dashboard/applications-management/applications-management.component';
import { LicensesManagementComponent } from '../dashboard/licenses-management/licenses-management.component';
import { services_routes } from './services.routes';

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
    component: ServicesComponent,
    children: services_routes,
  },
  {
    path: 'applicationsManagement',
    component: ApplicationsManagementComponent,
  },
  {
    path: 'licensesManagement',
    component: LicensesManagementComponent,
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
