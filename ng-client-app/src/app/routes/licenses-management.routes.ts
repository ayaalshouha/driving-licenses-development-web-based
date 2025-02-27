import { Routes } from '@angular/router';
import { DetainedLicensesComponent } from '../dashboard/licenses-management/detained-licenses/detained-licenses.component';
import { InternationalLicensesComponent } from '../dashboard/licenses-management/international-licenses/international-licenses.component';
import { driver_routes } from './driver.routes';
import { international_routes } from './international-routes.routes';

export const licenses_management_routes: Routes = [
  {
    path: 'detaiend-licenses',
    component: DetainedLicensesComponent,
  },
  {
    path: 'international-licenses',
    children: international_routes,
  },
  {
    path: 'drivers',
    children: driver_routes,
  },
];
