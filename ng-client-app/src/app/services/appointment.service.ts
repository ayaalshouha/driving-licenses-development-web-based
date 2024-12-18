import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { APPOINTMENT_API_ENDPOINT } from '../environments/endpoints/appointment.endpoints';
import { map, Observable } from 'rxjs';
import { Appointment, Appointment_View } from '../models/appointment.model';

@Injectable({
  providedIn: 'root',
})
export class AppointmentService {
  constructor(private http: HttpClient) {}

  create(new_appointment: Appointment): Observable<Appointment> {
    return this.http
      .post<Appointment>(APPOINTMENT_API_ENDPOINT.add, new_appointment)
      .pipe(
        map((res) => {
          return res;
        })
      );
  }
  isThereAnActiveAppointment(
    testType: number,
    localApp: number
  ): Observable<boolean> {
    return this.http.get<boolean>(
      APPOINTMENT_API_ENDPOINT.active_appointments(testType, localApp)
    );
  }
  appointments(): Observable<Appointment_View[]> {
    return this.http.get<Appointment_View[]>(APPOINTMENT_API_ENDPOINT.all);
  }
}
