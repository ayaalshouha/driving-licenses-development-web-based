import { Routes } from '@angular/router';
import { NewLocalApplicationComponent } from '../dashboard/services/new-local-application/new-local-application.component';
import { NewInternationalApplicationComponent } from '../dashboard/services/new-international-application/new-international-application.component';
import { LocalApplicationsComponent } from '../dashboard/applications-management/local-applications/local-applications.component';
import { InternationalApplicationsComponent } from '../dashboard/applications-management/international-applications/international-applications.component';

export const app_management_routes: Routes = [
  {
    path: 'LocalApplications',
    component: LocalApplicationsComponent,
  },
  {
    path: 'InternationalApplications',
    component: InternationalApplicationsComponent,
  },
];
