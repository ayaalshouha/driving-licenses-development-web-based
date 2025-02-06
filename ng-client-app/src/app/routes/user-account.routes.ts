import { Routes } from '@angular/router';
import { UserAccountComponent } from '../dashboard/user-account/user-account.component';
import { ChangePasswordComponent } from '../dashboard/user-account/change-password/change-password.component';

export const user_account_routes: Routes = [
  {
    path: '',
    component: UserAccountComponent,
  },
  {
    path: 'change-password',
    component: ChangePasswordComponent,
  },
];
