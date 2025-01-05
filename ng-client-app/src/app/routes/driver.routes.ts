import { Routes } from '@angular/router';
import { DriversComponent } from '../dashboard/licenses-management/drivers/drivers.component';
import { PreviewDriverComponent } from '../dashboard/licenses-management/drivers/preview-driver/preview-driver.component';
export const driver_routes: Routes = [
  {
    path: '',
    component: DriversComponent,
  },
  {
    path: 'preview-driver',
    component: PreviewDriverComponent,
  },
  {
    // path: 'driver-licenses-history',
    // component: DriverLicensesHistory,
  },
];
