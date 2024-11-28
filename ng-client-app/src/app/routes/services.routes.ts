import { Routes } from '@angular/router';
import { RenewLocalApplicationComponent } from '../dashboard/folder/renew-local-application/renew-local-application.component';
import { new_applications_routes } from './newApplications.routes';

export const services_routes: Routes = [
  {
    path: 'newApplication',
    children: new_applications_routes,
  },
  {
    path: 'renewLocalApp',
    component: RenewLocalApplicationComponent,
  },
];
