import { Routes } from '@angular/router';
import { ApplicationTypesComponent } from '../dashboard/system/application-types/application-types.component';
import { TestsComponent } from '../dashboard/system/tests/tests.component';
export const system_routes: Routes = [
  {
    path: 'application-types',
    component: ApplicationTypesComponent,
  },
  {
    path: 'manage-tests',
    component: TestsComponent,
  },
];
