import { Routes } from '@angular/router';
import { DetainedLicensesComponent } from '../dashboard/licenses-management/detained-licenses/detained-licenses.component';
import { DriversComponent } from '../dashboard/licenses-management/drivers/drivers.component';

export const licenses_management_routes: Routes = [
  {
    path: 'detaiend-licenses',
    component: DetainedLicensesComponent,
  },
  {
    path: 'drivers',
    component: DriversComponent,
  },
];
