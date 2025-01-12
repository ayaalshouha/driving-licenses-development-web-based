import { Routes } from '@angular/router';
import { NewInternationalApplicationComponent } from '../dashboard/services/new-international-application/new-international-application.component';
import { canDeactivate } from '../dashboard/services/new-local-application/new-local-application.component';

export const new_applications_routes: Routes = [
  {
    path: 'local',
    loadComponent: () =>
      import(
        '../dashboard/services/new-local-application/new-local-application.component'
      ).then((module) => module.NewLocalApplicationComponent),
    canDeactivate: [canDeactivate],
  },
  {
    path: 'international',
    loadComponent: () =>
      import(
        '../dashboard/services/new-international-application/new-international-application.component'
      ).then((module) => module.NewInternationalApplicationComponent),
  },
];
