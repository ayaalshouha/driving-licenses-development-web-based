import { Component, DestroyRef, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TestService } from '../../../services/test.service';
import { switchMap, tap } from 'rxjs';
import { Test } from '../../../models/test.model';
import { AppointmentService } from '../../../services/appointment.service';
import { Appointment_View } from '../../../models/appointment.model';
import { NotificationService } from '../../../services/notification.service';

@Component({
  selector: 'app-preview-test',
  standalone: true,
  imports: [],
  templateUrl: './preview-test.component.html',
  styleUrl: './preview-test.component.css',
})
export class PreviewTestComponent implements OnInit {
  testID: number | null = null;
  current_test: Test | undefined = undefined;
  current_appointment: Appointment_View | undefined = undefined;
  private destroyRef = inject(DestroyRef);
  constructor(
    private route: ActivatedRoute,
    private testService: TestService,
    private appoitnmentService: AppointmentService,
    private notifyServ: NotificationService
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
}
