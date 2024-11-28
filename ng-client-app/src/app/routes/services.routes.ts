import { Routes } from '@angular/router';
import { NewLocalApplicationComponent } from '../dashboard/services/new-local-application/new-local-application.component';
import { RenewLocalApplicationComponent } from '../dashboard/services/renew-local-application/renew-local-application.component';

export const services_routes: Routes = [
  {
    path: 'newLocalApp',
    component: NewLocalApplicationComponent,
  },
  {
    path: 'reNewLocalApp',
    component: RenewLocalApplicationComponent,
  },
];
