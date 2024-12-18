import { Component, DestroyRef, inject } from '@angular/core';
import { tap } from 'rxjs';
import { Appointment_View } from '../../../models/appointment.model';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { AppointmentService } from '../../../services/appointment.service';
@Component({
  selector: 'app-manage-appointments',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './manage-appointments.component.html',
  styleUrl: './manage-appointments.component.css',
})
export class ManageAppointmentsComponent {
  currentPage = 1;
  pageSize = 5;
  appointments: Appointment_View[] = [];
  filteredappointments: Appointment_View[] = [];
  displayedData: Appointment_View[] = [];
  private destroyRef = inject(DestroyRef);
  filter = new FormControl('', { nonNullable: true });

  constructor(private appointmentService: AppointmentService) {}

  ngOnInit(): void {
    const subscription = this.appointmentService
      .appointments()
      .pipe(
        tap((response) => {
          this.appointments = response;
          this.filteredappointments = response;
          this.updateDisplayedData();
        })
      )
      .subscribe();

    this.destroyRef.onDestroy(() => subscription.unsubscribe());
    this.filter.valueChanges
      .pipe(
        tap((value) => {
          this.applyFilter(value);
        })
      )
      .subscribe();
  }

  applyFilter(value: string) {
    const lowerCaseFilter = value.toLowerCase();
    this.filteredappointments = this.appointments.filter((item) =>
      Object.values(item).some((val) =>
        String(val).toLowerCase().includes(lowerCaseFilter)
      )
    );
    console.log('filtered applications', this.filteredappointments);
    this.currentPage = 1;
    this.updateDisplayedData();
  }

  updateDisplayedData() {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    this.displayedData = this.filteredappointments.slice(startIndex, endIndex);
  }
  onNext() {
    if (this.currentPage * this.pageSize < this.filteredappointments.length) {
      this.currentPage++;
      this.updateDisplayedData();
    }
  }
  onPrevious() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.updateDisplayedData();
    }
  }
}
