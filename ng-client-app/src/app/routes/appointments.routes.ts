import { Routes } from '@angular/router';
import { MakeAppointmentComponent } from '../dashboard/appointments/make-appointment/make-appointment.component';
import { ManageAppointmentsComponent } from '../dashboard/appointments/manage-appointments/manage-appointments.component';

export const appointments_routes: Routes = [
  {
    path: 'make-appointment',
    component: MakeAppointmentComponent,
  },
  {
    path: 'manage-appointments',
    component: ManageAppointmentsComponent,
  },
];
