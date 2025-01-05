import { Routes } from '@angular/router';
import { DriversComponent } from '../dashboard/licenses-management/drivers/drivers.component';
import { PreviewDriverComponent } from '../dashboard/licenses-management/drivers/preview-driver/preview-driver.component';
import { LicensesHistoryComponent } from '../dashboard/licenses-management/drivers/licenses-history/licenses-history.component';

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
    path: 'person-licenses-history',
    component: LicensesHistoryComponent,
  },
];
