import { Routes } from '@angular/router';
import { LocalApplicationsComponent } from '../dashboard/applications-management/local-applications/local-applications.component';
import { AddEditApplicationComponent } from '../dashboard/applications-management/add-edit-application/add-edit-application.component';
import { PreviewApplicationComponent } from '../dashboard/applications-management/preview-application/preview-application.component';

export const app_management_routes: Routes = [
  {
    path: 'local-applications',
    component: LocalApplicationsComponent,
  },
  {
    path: 'add-edit-application',
    component: AddEditApplicationComponent,
  },
  {
    path: 'preview-application',
    component: PreviewApplicationComponent,
  },
];
