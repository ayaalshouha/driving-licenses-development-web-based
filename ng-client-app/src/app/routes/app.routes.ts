import { Routes } from '@angular/router';
import { HomepageComponent } from '../homepage/homepage.component';
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
    loadComponent: () =>
      import('../dashboard/dashboard.component').then(
        (mod) => mod.DashboardComponent
      ),
    loadChildren: () =>
      import('./dashboard.routes').then((mod) => mod.dashboard_routes),
  },
  {
    path: 'add-new-app',
    loadComponent: () =>
      import(
        '../dashboard/services/new-local-application/new-local-application.component'
      ).then((module) => module.NewLocalApplicationComponent),
  },
];
