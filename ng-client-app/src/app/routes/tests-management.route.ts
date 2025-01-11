import { Routes } from '@angular/router';
import { PreviewTestComponent } from '../dashboard/tests-management/preview-test/preview-test.component';
import { TestsManagementComponent } from '../dashboard/tests-management/tests-management.component';

export const test_management_routes: Routes = [
  {
    path: 'tests',
    component: TestsManagementComponent,
  },
  {
    path: 'preview-test',
    component: PreviewTestComponent,
  },
];
