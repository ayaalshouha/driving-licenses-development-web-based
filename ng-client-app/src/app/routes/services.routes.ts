import { Routes } from '@angular/router';
import { new_applications_routes } from './newApplications.routes';
import { RenewLocalApplicationComponent } from '../dashboard/services/renew-local-application/renew-local-application.component';
import { ReplaceApplicationComponent } from '../dashboard/services/replace-application/replace-application.component';
import { ReleaseApplicationComponent } from '../dashboard/services/release-application/release-application.component';
import { RetakeTestApplicationComponent } from '../dashboard/services/retake-test-application/retake-test-application.component';
import { canDeactivate } from '../dashboard/services/new-local-application/new-local-application.component';

export const services_routes: Routes = [
  {
    path: 'new-application',
    children: new_applications_routes,
    canDeactivate: [canDeactivate],
  },
  {
    path: 'renew-local-app',
    canDeactivate: [canDeactivate],
    component: RenewLocalApplicationComponent,
  },
  {
    path: 'replace-app',
    canDeactivate: [canDeactivate],
    component: ReplaceApplicationComponent,
  },
  {
    path: 'release-app',
    canDeactivate: [canDeactivate],
    component: ReleaseApplicationComponent,
  },
  {
    path: 'retake-test-app',
    canDeactivate: [canDeactivate],
    component: RetakeTestApplicationComponent,
  },
];
