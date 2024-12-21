import { Component, signal } from '@angular/core';
import { enIssueReason, License } from '../../../models/license.model';
import { FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { map, Subject, switchMap, takeUntil, tap } from 'rxjs';
import { TestTypesService } from '../../../services/test-type.service';
import { ApplicationService } from '../../../services/application.service';
import { NotificationService } from '../../../services/notification.service';
import { LicenseService } from '../../../services/license.service';
import { Driver_View } from '../../../models/driver.model';
import { DriverService } from '../../../services/driver.service';
import {
  enLicenseClass,
  LicenseClass,
} from '../../../models/license-class.model';
import { CurrencyPipe } from '@angular/common';
import { NotificationComponent } from '../../../shared/notification/notification.component';
import { LicenseClassService } from '../../../services/license-class.service';
import { enApplicationType } from '../../../models/application.model';
import { ApplicationTypes } from '../../../models/application-type.model';

@Component({
  selector: 'app-renew-local-application',
  standalone: true,
  imports: [ReactiveFormsModule, CurrencyPipe, NotificationComponent],
  templateUrl: './renew-local-application.component.html',
  styleUrl: './renew-local-application.component.css',
})
export class RenewLocalApplicationComponent {
  current_license = signal<License | undefined>(undefined);
  new_license = signal<License | undefined>(undefined);
  current_driver = signal<Driver_View | undefined>(undefined);
  applicantName = signal<string | undefined>(undefined);
  issueReason = signal<string | undefined>(undefined);
  classes = signal<LicenseClass[] | undefined>(undefined);
  applicationTypeFee: number =
    ApplicationTypes[enApplicationType['Renew Driving License Service']]
      .typeFee;
  licenseClass = signal<string | undefined>(undefined);
  filter = new FormControl('', {
    validators: [Validators.required, Validators.min(1)],
  });
  active = true;
  expired = true;
  current_user_id = signal<number>(0);
  current_date = new Date();
  private destroy$ = new Subject<void>();

  constructor(
    private licenseService: LicenseService,
    private driverService: DriverService,
    private licenseClassService: LicenseClassService,
    private mainAppService: ApplicationService,
    private notificationService: NotificationService
  ) {}

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

    this.licenseClassService
      .getAllClasses()
      .pipe(
        tap((response) => this.classes.set(response)),
        takeUntil(this.destroy$)
      )
      .subscribe();
  }

  onSearch() {
    const licenseID: number = +this.filter.value!;

    this.licenseService
      .read(licenseID)
      .pipe(
        tap((license) => this.handleLicense(license)),
        switchMap((license) => {
          return this.driverService.read(license.driverID).pipe(
            tap((driver) => this.handleDriver(driver)),
            map(() => license)
          );
        }),
        tap((license) => {
          if (!license.isActive) {
            this.active = false;
            throw new Error(
              'The license is inactive. Please check with the administrator.'
            );
          }
          if (new Date(license.expDate) > this.current_date) {
            this.expired = false;
            throw new Error('The license is NOT expired yet.');
          }
        }),
        takeUntil(this.destroy$)
      )
      .subscribe({
        error: (err) => {
          this.notificationService.showMessage({
            message: err.message,
            status: 'failed',
          });
        },
      });
  }

  private handleLicense(license: License): void {
    this.current_license.set(license);
    this.licenseClass.set(enLicenseClass[license.licenseClass]);
    this.issueReason.set(enIssueReason[license.issueReason]);
  }

  private handleDriver(driver: Driver_View): void {
    this.current_driver.set(driver);
    this.applicantName.set(driver.fullName);
  }

  onReset() {
    this.current_driver.set(undefined);
    this.current_license.set(undefined);
    this.applicantName.set(undefined);
    this.licenseClass.set(undefined);
  }

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

  get ValidLicense() {
    return this.current_license() && this.expired && this.active;
  }
  onRenew() {
    if (!this.ValidLicense) {
      this.notificationService.showMessage({
        message: 'You cannot renew an invalid license!',
        status: 'failed',
      });
      return;
    }

    
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
