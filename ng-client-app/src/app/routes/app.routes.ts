import { Routes } from '@angular/router';
import { LoginComponent } from '../login/login.component';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { dashboard_routes } from './dashboard.routes';
import { HomepageComponent } from '../homepage/homepage.component';
import { NewLocalApplicationComponent } from '../dashboard/services/new-local-application/new-local-application.component';
export const routes: Routes = [
  {
    path: '',
    redirectTo: 'homepage',
    pathMatch: 'full',
  },
  {
    path: 'homepage',
    component: HomepageComponent,
  },
  {
    path: 'login',
    loadComponent: () =>
      import('../login/login.component').then(
        (module) => module.LoginComponent
      ),
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
    children: dashboard_routes,
  },
  {
    path: 'add-new-app',
    loadComponent: () =>
      import(
        '../dashboard/services/new-local-application/new-local-application.component'
      ).then((module) => module.NewLocalApplicationComponent),
  },
];
