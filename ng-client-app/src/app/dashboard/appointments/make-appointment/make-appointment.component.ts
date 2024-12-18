import { CurrencyPipe, DatePipe } from '@angular/common';
import { Component, signal } from '@angular/core';
import { FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { TestType } from '../../../models/test-type.model';
import { TestTypesService } from '../../../services/test-type.service';
import {
  catchError,
  forkJoin,
  pipe,
  Subject,
  switchMap,
  takeUntil,
  tap,
  throwError,
} from 'rxjs';
import { LocalApplication } from '../../../models/local-application.model';
import { LocalApplicationService } from '../../../services/local-application.service';
import {
  Application,
  enApplicationStatus,
  enApplicationType,
} from '../../../models/application.model';
import { ApplicationService } from '../../../services/application.service';
import { PersonService } from '../../../services/person.service';
import { enLicenseClass } from '../../../models/license-class.model';
import { NotificationComponent } from '../../../shared/notification/notification.component';
import { NotificationService } from '../../../services/notification.service';
import { Appointment } from '../../../models/appointment.model';
import { AppointmentService } from '../../../services/appointment.service';
import { subscribe } from 'diagnostics_channel';
import { ApplicationTypes } from '../../../models/application-type.model';
import { nextTick } from 'process';
@Component({
  selector: 'app-make-appointment',
  standalone: true,
  imports: [ReactiveFormsModule, DatePipe, CurrencyPipe, NotificationComponent],
  templateUrl: './make-appointment.component.html',
  styleUrl: './make-appointment.component.css',
})
export class MakeAppointmentComponent {
  current_local_application = signal<LocalApplication | null>(null);
  current_main_application = signal<Application | null>(null);
  applicantName = signal<string | undefined>(undefined);
  testCount = signal<number | undefined>(undefined);
  applicationType = signal<string | undefined>(undefined);
  applicationStatus = signal<string | undefined>(undefined);
  licenseClass = signal<string | undefined>(undefined);
  testTypeID = signal<number | undefined>(undefined);
  filter = new FormControl('', {
    validators: [Validators.required, Validators.min(1)],
  });
  appointmentDate = new FormControl('', {
    validators: [Validators.required],
  });
  current_date = new Date();
  testTypes: TestType[] = [];
  private destroy$ = new Subject<void>();

  constructor(
    private apppointmentService: AppointmentService,
    private testTypeService: TestTypesService,
    private applicationService: LocalApplicationService,
    private mainAppService: ApplicationService,
    private personService: PersonService,
    private notificationService: NotificationService
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

  checkTests() {
    if (this.testCount() == 3 && this.applicationStatus() == 'Completed') {
      this.testTypeID.set(undefined);
      this.notificationService.showMessage({
        message:
          'This person is already took the three tests, Check there license in Licenses Management section',
        status: 'notification',
      });
    } else if (this.testCount()! < 3) {
      this.testTypeID.set(this.testCount()!);
    }
  }

  onSearch() {
    const applicationID: number = +this.filter.value!;

    this.applicationService
      .read(applicationID)
      .pipe(
        switchMap((localApp) => {
          if (!localApp.id)
            return throwError(
              () => new Error('Invalid Local Application Data')
            );
          this.current_local_application.set(localApp);

          return this.mainAppService.read(localApp.applicationID).pipe(
            switchMap((mainApp) => {
              if (!mainApp.id)
                return throwError(
                  () => new Error('Invalid Main Application Data')
                );
              this.current_main_application.set(mainApp);

              this.applicationStatus.set(
                enApplicationStatus[this.current_main_application()!.status]
              );

              this.applicationType.set(
                enApplicationType[this.current_main_application()!.type]
              );
              this.licenseClass.set(
                enLicenseClass[this.current_local_application()!.licenseClassID]
              );

              return forkJoin({
                passedTest: this.applicationService.passedTestCount(
                  localApp.id
                ),
                applicantFullName: this.personService.getFullName(
                  mainApp.personID
                ),
              });
            })
          );
        }),
        takeUntil(this.destroy$) // Automatic cleanup
      )
      .subscribe({
        next: ({ passedTest, applicantFullName }) => {
          this.testCount.set(passedTest);
          this.applicantName.set(applicantFullName);
          this.checkTests();
        },
        error: (err) => {
          console.error('Error fetching data:', err.message);
        },
        complete: () => {
          console.log('Data fetching sequence completed');
        },
      });
  }

  onReset() {
    this.current_local_application.set(null);
    this.current_main_application.set(null);
    this.applicantName.set(undefined);
    this.licenseClass.set(undefined);
    this.applicationStatus.set(undefined);
    this.applicationType.set(undefined);
    this.testCount.set(undefined);
  }

  get invalidTestTypeID() {
    return this.testTypeID() == undefined;
  }

  private CreateRetakeTestAppointment() {
    const new_app: Application = {
      id: 0,
      personID: this.current_main_application()!.personID,
      paidFees: ApplicationTypes[enApplicationType['Retake Test']].typeFee,
      date: this.current_date,
      lastStatusDate: this.current_date,
      status: enApplicationStatus.New,
      type: enApplicationType['Retake Test'],
      createdByUserID: 3, // Replace with the actual user ID dynamically
    };

    return this.mainAppService.create(new_app).pipe(
      switchMap((newApp) => {
        if (!newApp) {
          throw new Error('Failed to create retake application');
        }
        const new_appointment: Appointment = {
          createdByUserID: 3, // Replace with the actual user ID dynamically
          id: 0,
          isLocked: false,
          date: new Date(this.appointmentDate.value!),
          paidFees: this.testTypes[this.testTypeID()!].fees,
          localLicenseApplicationID: this.current_local_application()!.id,
          retakeTestID: newApp.id,
          testType: this.testTypeID()! + 1,
        };

        return this.apppointmentService.create(new_appointment).pipe(
          catchError((err) => {
            throw new Error(
              `Error creating retake appointment: ${err.message}`
            );
          })
        );
      })
    );
  }

  private CreateNewAppointment() {
    const newAppointment: Appointment = {
      createdByUserID: 3,
      id: 0,
      isLocked: false,
      date: new Date(this.appointmentDate.value!),
      paidFees: this.testTypes[this.testTypeID()!].fees,
      localLicenseApplicationID: this.current_local_application()!.id,
      testType: this.testTypeID()! + 1,
      retakeTestID: null,
    };

    return this.apppointmentService.create(newAppointment).pipe(
      catchError((err) => {
        throw new Error(`Error creating new appointment: ${err.message}`);
      })
    );
  }
  onSchedule() {
    console.log(this.testTypeID());
    if (this.invalidTestTypeID) {
      this.notificationService.showMessage({
        message: 'You cannot schedule undefined test!',
        status: 'failed',
      });
      return;
    }

    if (this.appointmentDate.invalid) {
      this.notificationService.showMessage({
        message: 'Invalid date! Make sure to pick a date.',
        status: 'failed',
      });
      return;
    }
    //check if there is an ACTIVE (NOT LOCKED) appointment for the same test type

    this.apppointmentService
      .isThereAnActiveAppointment(
        this.testTypeID()! + 1,
        this.current_local_application()!.id
      )
      .pipe(
        switchMap((appointment_found) => {
          if (appointment_found) {
            return throwError(
              () =>
                new Error(
                  'Person already schaduled an appointment with same test type!'
                )
            );
          }
          return this.applicationService
            .isTestAttended(
              this.current_local_application()!.id,
              this.testTypeID()! + 1
            )
            .pipe(
              switchMap((isTestAttended) => {
                return isTestAttended
                  ? this.CreateRetakeTestAppointment()
                  : this.CreateNewAppointment();
              })
            );
        }),
        catchError((err) => {
          this.notificationService.showMessage({
            message: err.message || 'An unexpected error occured!!',
            status: 'failed',
          });
          return [];
        }),
        takeUntil(this.destroy$)
      )
      .subscribe({
        next: () => {
          this.notificationService.showMessage({
            message: 'Appointment scheduled successfully!',
            status: 'success',
          });
        },
        error: (err) => {
          console.error('Error scheduling appointment:', err);
        },
      });

    //is appointment locked with pass or fail result
    // check if there is a previous test type (FAILED/LOCKED)of the same one to assign a retake test

    // const new_appointment: Appointment = {
    //   id: 0,
    //   localLicenseApplicationID: this.current_local_application()!.id,
    //   isLocked: false,
    //   testType: this.testTypeID()!,
    //   paidFees: this.testTypes[this.testTypeID()!].fees,
    //   createdByUserID: 3,
    //   date:
    // };
  }
  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
