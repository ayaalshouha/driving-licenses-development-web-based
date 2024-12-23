import { Component, Inject, PLATFORM_ID, signal } from '@angular/core';
import { enIssueReason, License } from '../../../models/license.model';
import { FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { map, Subject, switchMap, takeUntil, tap } from 'rxjs';
import { NotificationService } from '../../../services/notification.service';
import { LicenseService } from '../../../services/license.service';
import { Driver_View } from '../../../models/driver.model';
import { DriverService } from '../../../services/driver.service';
import {
  enLicenseClass,
  LicenseClass,
} from '../../../models/license-class.model';
import { CurrencyPipe, isPlatformBrowser } from '@angular/common';
import { NotificationComponent } from '../../../shared/notification/notification.component';
import { LicenseClassService } from '../../../services/license-class.service';
import { enApplicationType } from '../../../models/application.model';
import { ApplicationTypes } from '../../../models/application-type.model';
import { ConfirmationDialogComponent } from '../../../shared/confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-renew-local-application',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CurrencyPipe,
    NotificationComponent,
    ConfirmationDialogComponent,
  ],
  templateUrl: './renew-local-application.component.html',
  styleUrl: './renew-local-application.component.css',
})
export class RenewLocalApplicationComponent {
  isConfirmed = signal<boolean>(false);
  isDialogVisible = signal<boolean>(false);
  current_license = signal<License | undefined>(undefined);
  new_license = signal<License | undefined>(undefined);
  current_driver = signal<Driver_View | undefined>(undefined);
  applicantName = signal<string | undefined>(undefined);
  issueReason = signal<string | undefined>(undefined);
  new_license_issue_reason = enIssueReason[enIssueReason['Renew License']];
  classes = signal<LicenseClass[] | undefined>(undefined);
  applicationTypeFee: number =
    ApplicationTypes[enApplicationType['Renew Driving License Service']]
      .typeFee;
  licenseClass = signal<string | undefined>(undefined);
  filter = new FormControl('', {
    validators: [Validators.required, Validators.min(1)],
  });
  notes = new FormControl('');
  active = true;
  expired = true;
  current_user_id = signal<number>(0);
  current_date = new Date();
  private destroy$ = new Subject<void>();

  constructor(
    @Inject(PLATFORM_ID) private platformId: Object,
    private licenseService: LicenseService,
    private driverService: DriverService,
    private licenseClassService: LicenseClassService,
    private notificationService: NotificationService
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

  onDialogResult(isConfirmed: boolean) {
    this.isDialogVisible.set(false);
    if (isConfirmed) {
      console.log('User confirmed the action.');
      this.processWithRenewal();
    } else {
      console.log('User canceled the action.');
      this.notificationService.showMessage({
        message: 'Renewal process canceled',
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

  private handleNewLicense(newLicense: License): void {
    this.new_license.set(newLicense);
    this.issueReason.set(enIssueReason[newLicense.issueReason]);
    this.current_license()!.isActive = false;
  }
  get ValidLicense(): boolean {
    console.log(`license exprired ${this.expired}`);
    console.log(`license active ${this.active}`);
    return this.current_license() != undefined && this.expired && this.active;
  }

  processWithRenewal() {
    if (!this.ValidLicense) {
      this.notificationService.showMessage({
        message: 'You cannot renew an invalid license!',
        status: 'failed',
      });
      return;
    }
    const notes: string | null = this.notes.value ? this.notes.value : null;
    this.licenseService
      .renew(this.current_license()!.id, notes!, this.current_user_id()!)
      .pipe(
        tap((new_license) => {
          this.handleNewLicense(new_license);
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
            message: 'License renewed successfully',
            status: 'success',
          });
        },
      });
  }

  onRenew() {
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
