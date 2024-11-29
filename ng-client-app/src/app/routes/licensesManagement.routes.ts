import { Routes } from '@angular/router';
import { LicensesComponent } from '../dashboard/licenses-management/licenses/licenses.component';
import { DriversComponent } from '../dashboard/licenses-management/drivers/drivers.component';

export const licenses_management_routes: Routes = [
  {
    path: 'licenses',
    component: LicensesComponent,
  },
  {
    path: 'drivers',
    component: DriversComponent,
  },
];
