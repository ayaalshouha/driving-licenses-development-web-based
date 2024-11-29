import { Routes } from '@angular/router';
import { new_applications_routes } from './newApplications.routes';
import { RenewLocalApplicationComponent } from '../dashboard/services/renew-local-application/renew-local-application.component';

export const services_routes: Routes = [
  {
    path: 'newApplication',
    children: new_applications_routes,
  },
  {
    path: 'renewLocalApp',
    component: RenewLocalApplicationComponent,
  },
  {

  },
  {
    
  }
];
