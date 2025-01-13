import { Routes } from '@angular/router';
import { InternationalLicensesComponent } from '../dashboard/licenses-management/international-licenses/international-licenses.component';
import { PreviewLicenseComponent } from '../dashboard/licenses-management/international-licenses/preview-license/preview-license.component';
import { PreviewDriverComponent } from '../dashboard/licenses-management/drivers/preview-driver/preview-driver.component';

export const international_routes: Routes = [
  {
    path: '',
    component: InternationalLicensesComponent,
  },
  {
    path: 'preview-internatioanl-license',
    component: PreviewLicenseComponent,
  },
  {
    path: 'preview-driver',
    component: PreviewDriverComponent,
  },
];
