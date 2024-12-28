import { CurrencyPipe, DatePipe } from '@angular/common';
import {
  Component,
  Input,
  OnInit,
  Output,
  signal,
  EventEmitter,
  OnChanges,
  SimpleChanges,
} from '@angular/core';
import { FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { TestType } from '../../../models/test-type.model';
import { TestTypesService } from '../../../services/test-type.service';
import {
  catchError,
  forkJoin,
  of,
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
import { ApplicationTypes } from '../../../models/application-type.model';

export enum enMode {
  add = 'Add appointment',
  edit = 'Edit appointment',
}
@Component({
  selector: 'app-make-appointment',
  standalone: true,
  imports: [ReactiveFormsModule, DatePipe, CurrencyPipe, NotificationComponent],
  templateUrl: './make-appointment.component.html',
  styleUrl: './make-appointment.component.css',
})
export class MakeAppointmentComponent implements OnInit, OnChanges {
  @Output() closed = new EventEmitter<boolean>();
  @Input() applicationID: number | null = null;
  appointments_mode = this.applicationID == null ? enMode.add : enMode.edit;
  enMode = enMode;
  current_local_application = signal<LocalApplication | null>(null);
  current_main_application = signal<Application | null>(null);
  applicantName = signal<string | undefined>(undefined);
  testCount = signal<number | undefined>(undefined);
  applicationType = signal<string | undefined>(undefined);
  applicationStatus = signal<string | undefined>(undefined);
  licenseClass = signal<string | undefined>(undefined);
  testTypeID = signal<number | undefined>(undefined);
  filter = new FormControl<number | undefined>(undefined, {
    validators: [Validators.required, Validators.min(1)],
  });
  appointmentDate = new FormControl('', {
    validators: [Validators.required],
  });
  current_user_id = signal<number>(0);
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
        }),
        takeUntil(this.destroy$)
      )
      .subscribe();
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['applicationID'] && changes['applicationID'].currentValue) {
      this.initializeMode();
      this.handleEditMode();
    }
  }
  private initializeMode(): void {
    this.appointments_mode =
      this.applicationID == null ? enMode.add : enMode.edit;
  }
  private handleEditMode(): void {
    if (this.appointments_mode === enMode.edit && this.applicationID) {
      this.filter.setValue(this.applicationID);
      console.log('filter value ' + this.filter.value);
      this.onSearch();
    } else {
      this.onReset();
    }
  }
  ngOnInit(): void {
    const current_user = localStorage.getItem('current-user');
    if (current_user) {
      try {
        const user = JSON.parse(current_user);
        this.current_user_id.set(user.id);
      } catch (error) {
        console.error('Error parsing user data from local storage:', error);
      }
    }
  }
  onClosed() {
    this.closed.emit(true);
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
    if (this.filter.value == undefined) {
      return;
    }

    const applicationID: number = +this.filter.value!;

    this.applicationService
      .read(applicationID)
      .pipe(
        tap((localApp) => this.current_local_application.set(localApp)),
        switchMap((localApp) =>
          this.mainAppService.read(localApp.applicationID).pipe(
            tap((mainApp) => {
              this.current_main_application.set(mainApp);
            }),
            switchMap((mainApp) =>
              forkJoin({
                passedTest: this.applicationService.passedTestCount(
                  localApp.id
                ),
                applicantFullName: this.personService.getFullName(
                  mainApp.personID
                ), // Using personID from mainApp
              }).pipe(
                tap(({ passedTest, applicantFullName }) => {
                  // Set values related to application status and type
                  this.applicationStatus.set(
                    enApplicationStatus[mainApp.status]
                  );
                  this.applicationType.set(enApplicationType[mainApp.type]);
                  this.licenseClass.set(
                    enLicenseClass[
                      this.current_local_application()!.licenseClassID
                    ]
                  );

                  // Set other values
                  this.testCount.set(passedTest);
                  this.applicantName.set(applicantFullName);

                  // Call checkTests() to determine test type
                  this.checkTests();
                }),
                switchMap(() => {
                  // Only retrieve the appointment if in "edit" mode
                  if (this.appointments_mode === enMode.edit) {
                    if (this.testTypeID() !== undefined) {
                      return this.apppointmentService
                        .appointment(this.testTypeID()! + 1, localApp.id)
                        .pipe(
                          tap((appointment) => {
                            if (appointment) {
                              const dateValue = new Date(appointment.date);
                              const localDate = new Date(
                                dateValue.getTime() -
                                  dateValue.getTimezoneOffset() * 60000
                              ); // Adjust for time zone offset
                              this.appointmentDate.setValue(
                                localDate.toISOString().split('T')[0]
                              );
                            }
                          })
                        );
                    }
                  }
                  return of(null);
                })
              )
            )
          )
        ),
        takeUntil(this.destroy$)
      )
      .subscribe({
        error: (err) => {
          this.notificationService.showMessage({
            message: err.message,
            status: 'failed',
          });
          this.onReset();
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
      createdByUserID: this.current_user_id(),
    };

    return this.mainAppService.create(new_app).pipe(
      switchMap((newApp) => {
        if (!newApp) {
          throw new Error('Failed to create retake application');
        }
        const new_appointment: Appointment = {
          createdByUserID: this.current_user_id(),
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
      createdByUserID: this.current_user_id(),
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
    // handle edit appointment date ONLY
    if (this.appointments_mode == enMode.edit) {
      console.log('this is gonna update the date ');
      return;
      // edit only the date
    }
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
  }
  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
