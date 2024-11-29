import { Routes } from '@angular/router';
import { new_applications_routes } from './newApplications.routes';
import { RenewLocalApplicationComponent } from '../dashboard/services/renew-local-application/renew-local-application.component';
import { ReplaceApplicationComponent } from '../dashboard/services/replace-application/replace-application.component';
import { ReleaseApplicationComponent } from '../dashboard/services/release-application/release-application.component';
import { RetakeTestApplicationComponent } from '../dashboard/services/retake-test-application/retake-test-application.component';

export const services_routes: Routes = [
  {
    path: 'new-application',
    children: new_applications_routes,
  },
  {
    path: 'renew-local-app',
    component: RenewLocalApplicationComponent,
  },
  {
    path: 'replace-app',
    component: ReplaceApplicationComponent,
  },
  {
    path: 'release-app',
    component: ReleaseApplicationComponent,
  },
  {
    path: 'retake-test-app',
    component: RetakeTestApplicationComponent,
  },
];
