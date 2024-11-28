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
    path: 'services',
    // component:
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
