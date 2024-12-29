import { Routes } from '@angular/router';
import { MakeAppointmentComponent } from '../dashboard/appointments/make-appointment/make-appointment.component';
import { ManageAppointmentsComponent } from '../dashboard/appointments/manage-appointments/manage-appointments.component';
import { AddEditAppointmentComponent } from '../dashboard/appointments/add-edit-appointment/add-edit-appointment.component';
import { TakeTestComponent } from '../dashboard/appointments/take-test/take-test.component';

export const appointments_routes: Routes = [
  {
    path: 'make-appointment',
    component: MakeAppointmentComponent,
  },
  {
    path: 'manage-appointments',
    component: ManageAppointmentsComponent,
  },
  {
    path: 'add-edit-appointment',
    component: AddEditAppointmentComponent,
  },
  {
    path: 'take-test',
    component: TakeTestComponent,
  },
];
