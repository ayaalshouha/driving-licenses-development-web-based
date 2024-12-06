import { Routes } from '@angular/router';
import { NewLocalApplicationComponent } from '../dashboard/services/new-local-application/new-local-application.component';
import { NewInternationalApplicationComponent } from '../dashboard/services/new-international-application/new-international-application.component';
// import { canDeactivate } from '../dashboard/services/new-local-application/new-local-application.component';

export const new_applications_routes: Routes = [
  {
    path: 'local',
    component: NewLocalApplicationComponent,
    // canDeactivate: [canDeactivate],
  },
  {
    path: 'international',
    component: NewInternationalApplicationComponent,
  },
];
