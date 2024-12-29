import { Component, OnDestroy, OnInit, signal } from '@angular/core';
import { AppointmentService } from '../../../services/appointment.service';
import { TestService } from '../../../services/test.service';
import { Test } from '../../../models/test.model';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { catchError, Subject, takeUntil, tap, throwError } from 'rxjs';
import { ConfirmationDialogComponent } from '../../../shared/confirmation-dialog/confirmation-dialog.component';
import { NotificationService } from '../../../services/notification.service';
import { NotificationComponent } from '../../../shared/notification/notification.component';
import { Appointment_View } from '../../../models/appointment.model';
import { TestType } from '../../../models/test-type.model';
import { TestTypesService } from '../../../services/test-type.service';
import { error } from 'console';
@Component({
  selector: 'app-take-test',
  standalone: true,
  imports: [ConfirmationDialogComponent, NotificationComponent],
  templateUrl: './take-test.component.html',
  styleUrl: './take-test.component.css',
})
export class TakeTestComponent implements OnInit, OnDestroy {
  id: number | null = null;
  test: Test | null = null;
  appointment: Appointment_View | null = null;
  isDialogVisible = signal<boolean>(false);
  private destroy$ = new Subject<void>();
  testTypes: TestType[] | null = null;
  constructor(
    private route: ActivatedRoute,
    private appointmetnService: AppointmentService,
    private testService: TestService,
    private location: Location,
    private notificationService: NotificationService,
    private testTypeService: TestTypesService
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => (this.id = +params['id']));
    // retrieving test types
    this.testTypeService
      .all()
      .pipe(
        catchError((error) => {
          return throwError(() => new Error(error));
        }),
        tap((types) => {
          this.testTypes = types;
        }),
        takeUntil(this.destroy$)
      )
      .subscribe({
        error: (error) => {
          this.notificationService.showMessage({
            message: error.message,
            status: 'failed',
          });
        },
      });

      // retrieving appointment 
    if (this.id) {
      this.appointmetnService
        .readView(this.id!)
        .pipe(
          catchError((error) => throwError(() => new Error(error.messages))),
          tap((appointment_info) => {
            if (appointment_info) {
              this.appointment = appointment_info;
            }
          }),
          takeUntil(this.destroy$)
        )
        .subscribe({
          // next: () => {
          //   this.notificationService.showMessage({
          //     message: 'Test saved successfully',
          //     status: 'success',
          //   });
          // },
          error: (error) => {
            this.notificationService.showMessage({
              message: error.message,
              status: 'failed',
            });
          },
        });
    }
  }
  CrateTest() {}
  onDialogResult(isConfirmed: boolean) {
    this.isDialogVisible.set(false);
    if (isConfirmed) {
      this.CrateTest();
    } else {
      this.notificationService.showMessage({
        message: 'Saving test result canceled',
        status: 'notification',
      });
    }
  }

  onSubmit() {
    this.isDialogVisible.set(true);
  }

  onCancel() {
    this.location.back();
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
