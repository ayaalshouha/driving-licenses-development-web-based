import { Component, DestroyRef, inject } from '@angular/core';
import { Subject, takeUntil, tap } from 'rxjs';
import { Appointment_View } from '../../../models/appointment.model';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { AppointmentService } from '../../../services/appointment.service';
import { TestType } from '../../../models/test-type.model';
import { TestTypesService } from '../../../services/test-type.service';
import { DatePipe } from '@angular/common';
import { RouterLink } from '@angular/router';
@Component({
  selector: 'app-manage-appointments',
  standalone: true,
  imports: [ReactiveFormsModule, DatePipe, RouterLink],
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
  testTypes: TestType[] = [];
  private destroy$ = new Subject<void>();
  current_date = new Date();
  
  constructor(
    private appointmentService: AppointmentService,
    private testTypeService: TestTypesService
  ) {
    this.testTypeService
      .all()
      .pipe(
        tap((response) => {
          this.testTypes = response;
          // console.log(this.testTypes[2]);
        }),
        takeUntil(this.destroy$)
      )
      .subscribe();
  }

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
  isSameDate(date1: string, date2: string): boolean {
    const d1 = new Date(date1);
    const d2 = new Date(date2);
    return (
      d1.getFullYear() === d2.getFullYear() &&
      d1.getMonth() === d2.getMonth() &&
      d1.getDate() === d2.getDate()
    );
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
