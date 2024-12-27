import { Component, Inject, PLATFORM_ID, signal } from '@angular/core';
import { enIssueReason, License } from '../../../models/license.model';
import { Driver_View } from '../../../models/driver.model';
import {
  enLicenseClass,
  LicenseClass,
} from '../../../models/license-class.model';
import { ApplicationTypes } from '../../../models/application-type.model';
import { enApplicationType } from '../../../models/application.model';
import { FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { CurrencyPipe, DatePipe, isPlatformBrowser } from '@angular/common';
import { map, Subject, switchMap, takeUntil, tap } from 'rxjs';
import { LicenseService } from '../../../services/license.service';
import { DriverService } from '../../../services/driver.service';
import { LicenseClassService } from '../../../services/license-class.service';
import { NotificationService } from '../../../services/notification.service';
import { ConfirmationDialogComponent } from '../../../shared/confirmation-dialog/confirmation-dialog.component';
import { NotificationComponent } from '../../../shared/notification/notification.component';
import { DetainedLicenseService } from '../../../services/detained-license.service';
import { DetainedLicense } from '../../../models/detained-license.model';

@Component({
  selector: 'app-release-application',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CurrencyPipe,
    ConfirmationDialogComponent,
    DatePipe,
    NotificationComponent,
  ],
  templateUrl: './release-application.component.html',
  styleUrl: './release-application.component.css',
})
export class ReleaseApplicationComponent {
  isConfirmed = signal<boolean>(false);
  isDialogVisible = signal<boolean>(false);
  current_license = signal<License | undefined>(undefined);
  detain_info = signal<DetainedLicense | undefined>(undefined);
  current_driver = signal<Driver_View | undefined>(undefined);
  applicantName = signal<string | undefined>(undefined);
  issueReason = signal<string | undefined>(undefined);
  classes = signal<LicenseClass[] | undefined>(undefined);
  applicationTypeFee: number =
    ApplicationTypes[enApplicationType['Release Detained Driving License']]
      .typeFee;
  licenseClass = signal<string | undefined>(undefined);
  filter = new FormControl(undefined, {
    validators: [Validators.required, Validators.min(1)],
  });
  notes = new FormControl('');
  active = false;
  expired = false;
  current_user_id = signal<number>(0);
  current_date = new Date();
  private destroy$ = new Subject<void>();
  isDetaiend = signal<boolean | undefined>(undefined);

  constructor(
    @Inject(PLATFORM_ID) private platformId: Object,
    private licenseService: LicenseService,
    private driverService: DriverService,
    private licenseClassService: LicenseClassService,
    private notificationService: NotificationService,
    private detainedLicenseService: DetainedLicenseService
  ) {}

  ngOnInit(): void {
    if (isPlatformBrowser(this.platformId)) {
      const current_user = window.localStorage.getItem('current-user');
      if (current_user) {
        try {
          const user = JSON.parse(current_user);
          this.current_user_id.set(user.id);
        } catch (error) {
          console.error('Error parsing user data from local storage:', error);
        }
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
    if (this.filter.value == undefined) {
      return;
    }
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
          if (license.isActive) {
            this.active = true;
            this.isDetaiend.set(false);
            throw new Error('The license is active and NOT detained.');
          }
          if (new Date(license.expDate) < this.current_date) {
            this.expired = true;
            throw new Error(
              'The license is expired, You cannot release an expired license  '
            );
          }
        }),
        switchMap((license) => {
          return this.licenseService.isDetained(license.id).pipe(
            switchMap((isDetained) => {
              if (!isDetained) {
                this.isDetaiend.set(false);
                throw new Error('License is NOT detained!');
              }
              this.isDetaiend.set(true);
              return this.detainedLicenseService.read(license.id).pipe(
                tap((detainInfo) => {
                  this.detain_info.set(detainInfo);
                })
              );
            })
          );
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

  onDialogResult(isConfirmed: boolean) {
    this.isDialogVisible.set(false);
    if (isConfirmed) {
      this.processWithRelease();
    } else {
      this.notificationService.showMessage({
        message: 'Release license process canceled',
        status: 'notification',
      });
    }
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
  get ValidLicense(): boolean {
    console.log('is detained = ' + this.isDetaiend());
    return (
      this.current_license() != undefined &&
      !this.active &&
      this.isDetaiend() == true
    );
  }

  processWithRelease() {
    if (!this.ValidLicense) {
      this.notificationService.showMessage({
        message: 'You cannot release an invalid license!',
        status: 'failed',
      });
      return;
    }
    this.licenseService
      .release(this.current_license()!.id, this.current_user_id()!)
      .pipe(
        tap((released) => {
          if (released) {
            this.current_license()!.isActive = true;
          }
        }),
        switchMap(() => {
          return this.detainedLicenseService
            .read(this.current_license()!.id)
            .pipe(
              tap((updatedDetainInfo) => {
                this.detain_info.set(updatedDetainInfo);
              })
            );
        }),
        takeUntil(this.destroy$)
      )
      .subscribe({
        next: () => {},
        error: (err) => {
          this.notificationService.showMessage({
            message: err.message,
            status: 'failed',
          });
        },
        complete: () => {
          this.notificationService.showMessage({
            message: 'License released successfully',
            status: 'success',
          });
          this.isDetaiend.set(false);
        },
      });
  }

  onRelease() {
    this.isDialogVisible.set(true);
  }
  onReset() {
    this.current_driver.set(undefined);
    this.current_license.set(undefined);
    this.applicantName.set(undefined);
    this.licenseClass.set(undefined);
  }
  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
