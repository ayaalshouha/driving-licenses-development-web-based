import { Routes } from '@angular/router';
import { ApplicationTypesComponent } from '../dashboard/system/application-types/application-types.component';
import { TestsComponent } from '../dashboard/system/tests/tests.component';
import { AddEditTypeComponent } from '../dashboard/system/add-edit-type/add-edit-type.component';
export const system_routes: Routes = [
  {
    path: 'application-types',
    component: ApplicationTypesComponent,
  },
  {
    path: 'manage-tests',
    component: TestsComponent,
  },
  {
    path: 'add-edit-type',
    component: AddEditTypeComponent,
  },
];
