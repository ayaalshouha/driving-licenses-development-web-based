import { Component, signal } from '@angular/core';
import { enIssueReason, License } from '../../../models/license.model';
import { FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { Subject, switchMap, takeUntil, tap } from 'rxjs';
import { AppointmentService } from '../../../services/appointment.service';
import { TestTypesService } from '../../../services/test-type.service';
import { LocalApplicationService } from '../../../services/local-application.service';
import { ApplicationService } from '../../../services/application.service';
import { PersonService } from '../../../services/person.service';
import { NotificationService } from '../../../services/notification.service';
import { LicenseService } from '../../../services/license.service';
import { Driver, Driver_View } from '../../../models/driver.model';
import { DriverService } from '../../../services/driver.service';
import { enLicenseClass } from '../../../models/license-class.model';
import { CurrencyPipe } from '@angular/common';
import { NotificationComponent } from '../../../shared/notification/notification.component';

@Component({
  selector: 'app-renew-local-application',
  standalone: true,
  imports: [ReactiveFormsModule, CurrencyPipe, NotificationComponent],
  templateUrl: './renew-local-application.component.html',
  styleUrl: './renew-local-application.component.css',
})
export class RenewLocalApplicationComponent {
  current_license = signal<License | null>(null);
  current_driver = signal<Driver_View | null>(null);
  applicantName = signal<string | undefined>(undefined);
  issueReason = signal<string | undefined>(undefined);
  // applicationType = signal<string | undefined>(undefined);
  // applicationStatus = signal<string | undefined>(undefined);
  licenseClass = signal<string | undefined>(undefined);
  // testTypeID = signal<number | undefined>(undefined);
  filter = new FormControl('', {
    validators: [Validators.required, Validators.min(1)],
  });

  current_user_id = signal<number>(0);
  current_date = new Date();
  private destroy$ = new Subject<void>();

  constructor(
    private licenseService: LicenseService,
    private driverService: DriverService,
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
          // this.testTypes = response;
          // console.log(this.testTypes[2]);
        }),
        takeUntil(this.destroy$)
      )
      .subscribe();
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

  // checkTests() {
  //   if (this.testCount() == 3 && this.applicationStatus() == 'Completed') {
  //     this.testTypeID.set(undefined);
  //     this.notificationService.showMessage({
  //       message:
  //         'This person is already took the three tests, Check there license in Licenses Management section',
  //       status: 'notification',
  //     });
  //   } else if (this.testCount()! < 3) {
  //     this.testTypeID.set(this.testCount()!);
  //   }
  // }

  onSearch() {
    const licenseID: number = +this.filter.value!;

    this.licenseService
      .read(licenseID)
      .pipe(
        tap((license) => {
          this.current_license.set(license);
          this.licenseClass.set(
            enLicenseClass[this.current_license()!.licenseClass]
          );
          this.issueReason.set(
            enIssueReason[this.current_license()!.issueReason]
          );
        }),
        switchMap((license) => {
          return this.driverService.read(license.driverID).pipe(
            tap((driver) => this.current_driver.set(driver))
            // switchMap((mainApp) => {
            //   this.applicationStatus.set(
            //     enApplicationStatus[this.current_main_application()!.status]
            //   );

            //   this.applicationType.set(
            //     enApplicationType[this.current_main_application()!.type]
            //   );

            //   return forkJoin({
            //     passedTest: this.applicationService.passedTestCount(
            //       localApp.id
            //     ),
            //     applicantFullName: this.personService.getFullName(
            //       mainApp.personID
            //     ),
            //   });
            // })
          );
        }),
        takeUntil(this.destroy$) // Automatic cleanup
      )
      .subscribe({
        // next: ({ passedTest, applicantFullName }) => {
        //   this.testCount.set(passedTest);
        //   this.applicantName.set(applicantFullName);
        //   this.checkTests();
        // },
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
    this.current_driver.set(null);
    this.current_license.set(null);
    this.applicantName.set(undefined);
    this.licenseClass.set(undefined);
    // this.applicationStatus.set(undefined);
    // this.applicationType.set(undefined);
    // this.testCount.set(undefined);
  }

  // get invalidTestTypeID() {
  //   return this.testTypeID() == undefined;
  // }

  // private CreateRetakeTestAppointment() {
  //   const new_app: Application = {
  //     id: 0,
  //     personID: this.current_main_application()!.personID,
  //     paidFees: ApplicationTypes[enApplicationType['Retake Test']].typeFee,
  //     date: this.current_date,
  //     lastStatusDate: this.current_date,
  //     status: enApplicationStatus.New,
  //     type: enApplicationType['Retake Test'],
  //     createdByUserID: this.current_user_id(),
  //   };

  //   return this.mainAppService.create(new_app).pipe(
  //     switchMap((newApp) => {
  //       if (!newApp) {
  //         throw new Error('Failed to create retake application');
  //       }
  //       const new_appointment: Appointment = {
  //         createdByUserID: this.current_user_id(),
  //         id: 0,
  //         isLocked: false,
  //         date: new Date(this.appointmentDate.value!),
  //         paidFees: this.testTypes[this.testTypeID()!].fees,
  //         localLicenseApplicationID: this.current_local_application()!.id,
  //         retakeTestID: newApp.id,
  //         testType: this.testTypeID()! + 1,
  //       };

  //       return this.apppointmentService.create(new_appointment).pipe(
  //         catchError((err) => {
  //           throw new Error(
  //             `Error creating retake appointment: ${err.message}`
  //           );
  //         })
  //       );
  //     })
  //   );
  // }

  // private CreateNewAppointment() {
  //   const newAppointment: Appointment = {
  //     createdByUserID: this.current_user_id(),
  //     id: 0,
  //     isLocked: false,
  //     date: new Date(this.appointmentDate.value!),
  //     paidFees: this.testTypes[this.testTypeID()!].fees,
  //     localLicenseApplicationID: this.current_local_application()!.id,
  //     testType: this.testTypeID()! + 1,
  //     retakeTestID: null,
  //   };

  //   return this.apppointmentService.create(newAppointment).pipe(
  //     catchError((err) => {
  //       throw new Error(`Error creating new appointment: ${err.message}`);
  //     })
  //   );
  // }
  onRenew() {
    //   if (this.invalidTestTypeID) {
    //     this.notificationService.showMessage({
    //       message: 'You cannot schedule undefined test!',
    //       status: 'failed',
    //     });
    //     return;
    //   }
    //   if (this.appointmentDate.invalid) {
    //     this.notificationService.showMessage({
    //       message: 'Invalid date! Make sure to pick a date.',
    //       status: 'failed',
    //     });
    //     return;
    //   }
    //   this.apppointmentService
    //     .isThereAnActiveAppointment(
    //       this.testTypeID()! + 1,
    //       this.current_local_application()!.id
    //     )
    //     .pipe(
    //       switchMap((appointment_found) => {
    //         if (appointment_found) {
    //           return throwError(
    //             () =>
    //               new Error(
    //                 'Person already schaduled an appointment with same test type!'
    //               )
    //           );
    //         }
    //         return this.applicationService
    //           .isTestAttended(
    //             this.current_local_application()!.id,
    //             this.testTypeID()! + 1
    //           )
    //           .pipe(
    //             switchMap((isTestAttended) => {
    //               return isTestAttended
    //                 ? this.CreateRetakeTestAppointment()
    //                 : this.CreateNewAppointment();
    //             })
    //           );
    //       }),
    //       catchError((err) => {
    //         this.notificationService.showMessage({
    //           message: err.message || 'An unexpected error occured!!',
    //           status: 'failed',
    //         });
    //         return [];
    //       }),
    //       takeUntil(this.destroy$)
    //     )
    //     .subscribe({
    //       next: () => {
    //         this.notificationService.showMessage({
    //           message: 'Appointment scheduled successfully!',
    //           status: 'success',
    //         });
    //       },
    //       error: (err) => {
    //         console.error('Error scheduling appointment:', err);
    //       },
    //     });
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
