import { Routes } from '@angular/router';
import { LocalApplicationsComponent } from '../dashboard/applications-management/local-applications/local-applications.component';
import { InternationalApplicationsComponent } from '../dashboard/applications-management/international-applications/international-applications.component';

export const app_management_routes: Routes = [
  {
    path: 'local-applications',
    component: LocalApplicationsComponent,
  },
  {
    path: 'international-applications',
    component: InternationalApplicationsComponent,
  },
];
