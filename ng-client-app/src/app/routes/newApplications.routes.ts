import { Routes } from '@angular/router';
import { NewLocalApplicationComponent } from '../dashboard/folder/new-local-application/new-local-application.component';
import { NewInternationalApplicationComponent } from '../dashboard/folder/new-international-application/new-international-application.component';

export const new_applications_routes: Routes = [
  {
    path: 'Local',
    component: NewLocalApplicationComponent,
  },
  {
    path: 'International',
    component: NewInternationalApplicationComponent,
  },
];
