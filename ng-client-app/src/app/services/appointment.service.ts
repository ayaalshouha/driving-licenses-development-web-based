import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { APPOINTMENT_API_ENDPOINT } from '../environments/endpoints/appointment.endpoints';
import { catchError, map, Observable, throwError } from 'rxjs';
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

  appointment(testType: number, localAppID: number): Observable<Appointment> {
    return this.http
      .get<Appointment>(APPOINTMENT_API_ENDPOINT.read(testType, localAppID))
      .pipe(
        catchError((error) => {
          if (error.status == 404) {
            throwError(() => new Error('No Appointment Found'));
          }
          return throwError(() => new Error('An unexpected error happened'));
        }),
        map((response) => {
          return response;
        })
      );
  }

  updateDate(id: number, new_date: string): Observable<boolean> {
    return this.http
      .get<boolean>(APPOINTMENT_API_ENDPOINT.updateDate(id, new_date))
      .pipe(
        catchError((error) => {
          if (error.status == 404) {
            throwError(() => new Error(`Appointment ${id} NOT Found`));
          }
          return throwError(() => new Error(`An unexpected error happend`));
        }),
        map((response) => {
          return response;
        })
      );
  }
}
