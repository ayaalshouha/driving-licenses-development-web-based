import { Routes } from '@angular/router';
import { TestComponent } from '../dashboard/test/test.component';
import { ServicesComponent } from '../dashboard/services/services.component';

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
