import { Routes } from '@angular/router';
import { UserAccountComponent } from '../dashboard/user-account/user-account.component';

export const user_account_routes: Routes = [
  {
    path: '',
    component: UserAccountComponent,
  },
  {
    path: 'change-password',
    // component: ChangePassword
  },
];
