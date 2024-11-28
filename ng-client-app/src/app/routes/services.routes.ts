import { Routes } from '@angular/router';
import { NewLocalApplicationComponent } from '../dashboard/services/new-local-application/new-local-application.component';
import { RenewLocalApplicationComponent } from '../dashboard/services/renew-local-application/renew-local-application.component';
import { new_applications_routes } from './newApplications.routes';

export const services_routes: Routes = [
  {
    path: 'newApplication',
    // component: NewLocalApplicationComponent,
    children: new_applications_routes,
  },
  {
    path: 'renewLocalApp',
    component: RenewLocalApplicationComponent,
  },
];
