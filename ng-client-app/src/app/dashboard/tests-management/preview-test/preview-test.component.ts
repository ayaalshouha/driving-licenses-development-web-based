import { Component, DestroyRef, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TestService } from '../../../services/test.service';
import { switchMap, tap } from 'rxjs';
import { Test } from '../../../models/test.model';
import { AppointmentService } from '../../../services/appointment.service';
import { Appointment_View } from '../../../models/appointment.model';
import { NotificationService } from '../../../services/notification.service';
import { NotificationComponent } from '../../../shared/notification/notification.component';
import { DialogWrapperComponent } from '../../../shared/dialog-wrapper/dialog-wrapper.component';
import { TestType } from '../../../models/test-type.model';
import { TestTypesService } from '../../../services/test-type.service';
import { DatePipe, Location } from '@angular/common';
@Component({
  selector: 'app-preview-test',
  standalone: true,
  imports: [NotificationComponent, DialogWrapperComponent, DatePipe],
  templateUrl: './preview-test.component.html',
  styleUrl: './preview-test.component.css',
})
export class PreviewTestComponent implements OnInit {
  testID: number | null = null;
  current_test: Test | undefined = undefined;
  current_appointment: Appointment_View | undefined = undefined;
  testTypesArr: TestType[] = [];
  private destroyRef = inject(DestroyRef);
  constructor(
    private location: Location,
    private route: ActivatedRoute,
    private testService: TestService,
    private appoitnmentService: AppointmentService,
    private notifyServ: NotificationService,
    private testTypeServ: TestTypesService
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.testID = params['id'];
    });

    this.loadTest();
  }

  loadTest() {
    if (this.testID) {
      const subscription = this.testService
        .read(this.testID!)
        .pipe(
          tap((response) => {
            if (response) {
              this.current_test = response;
            }
          }),
          switchMap((response) => {
            return this.appoitnmentService
              .readView(response.appointmentID)
              .pipe(tap((response) => (this.current_appointment = response)));
          }),
          switchMap((response) => {
            return this.testTypeServ.all().pipe(
              tap((response) => {
                this.testTypesArr = response;
              })
            );
          })
        )
        .subscribe({
          error: (error) => {
            this.notifyServ.showMessage({
              message: error.message,
              status: 'failed',
            });
          },
        });
      this.destroyRef.onDestroy(() => subscription.unsubscribe());
    }
  }

  onClose() {
    this.location.back();
  }
}
