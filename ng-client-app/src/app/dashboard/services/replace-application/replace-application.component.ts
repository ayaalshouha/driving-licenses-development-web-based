import { CurrencyPipe, isPlatformBrowser } from '@angular/common';
import { Component, Inject, OnDestroy, PLATFORM_ID, signal } from '@angular/core';
import { FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { NotificationComponent } from '../../../shared/notification/notification.component';
import { ConfirmationDialogComponent } from '../../../shared/confirmation-dialog/confirmation-dialog.component';
import { enIssueReason, License } from '../../../models/license.model';
import { Driver_View } from '../../../models/driver.model';
import {
  enLicenseClass,
  LicenseClass,
} from '../../../models/license-class.model';
import { ApplicationTypes } from '../../../models/application-type.model';
import { enApplicationType } from '../../../models/application.model';
import { map, Subject, switchMap, takeUntil, tap } from 'rxjs';
import { LicenseService } from '../../../services/license.service';
import { DriverService } from '../../../services/driver.service';
import { LicenseClassService } from '../../../services/license-class.service';
import { NotificationService } from '../../../services/notification.service';

enum enMode {
  damage = 1,
  lost,
}
@Component({
  selector: 'app-replace-application',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CurrencyPipe,
    NotificationComponent,
    ConfirmationDialogComponent,
  ],
  templateUrl: './replace-application.component.html',
  styleUrl: './replace-application.component.css',
})
export class ReplaceApplicationComponent implements OnDestroy{
  replace_mode: enMode | undefined = undefined;
  isConfirmed = signal<boolean>(false);
  isDialogVisible = signal<boolean>(false);
  current_license = signal<License | undefined>(undefined);
  new_license = signal<License | undefined>(undefined);
  current_driver = signal<Driver_View | undefined>(undefined);
  applicantName = signal<string | undefined>(undefined);
  issueReason = signal<string | undefined>(undefined);
  new_license_issue_reason = enIssueReason[enIssueReason['Lost Replacement']];
  classes = signal<LicenseClass[] | undefined>(undefined);
  applicationTypeFee: number | undefined =
    ApplicationTypes[enApplicationType['Replacement for Lost Driving License']]
      .typeFee;

  licenseClass = signal<string | undefined>(undefined);
  filter = new FormControl(undefined, {
    validators: [Validators.required, Validators.min(1)],
  });
  replaceMode = new FormControl<'Lost' | 'Damage'>('Lost');
  active = true;
  current_user_id = signal<number>(0);
  current_date = new Date();
  private destroy$ = new Subject<void>();

  constructor(
    @Inject(PLATFORM_ID) private platformId: Object,
    private licenseService: LicenseService,
    private driverService: DriverService,
    private licenseClassService: LicenseClassService,
    private notificationService: NotificationService
  ) {
    this.replaceMode.valueChanges
      .pipe(
        tap((value) => {
          if (value == 'Lost') {
            this.replace_mode = enMode.lost;
            this.applicationTypeFee =
              ApplicationTypes[
                enApplicationType['Replacement for Lost Driving License']
              ].typeFee;
            this.new_license_issue_reason =
              enIssueReason[enIssueReason['Lost Replacement']];
          } else if (value == 'Damage') {
            this.replace_mode = enMode.damage;
            this.applicationTypeFee =
              ApplicationTypes[
                enApplicationType['Replacement for Damaged Driving License']
              ].typeFee;
            this.new_license_issue_reason =
              enIssueReason[enIssueReason['Damaged Replacement']];
          }
        })
      )
      .subscribe();
  }

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
          if (!license.isActive) {
            this.active = false;
            throw new Error(
              'The license is inactive. Please check with the administrator.'
            );
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
      this.processWithReplacement();
    } else {
      this.notificationService.showMessage({
        message: 'Replacement process canceled',
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
    return this.current_license() != undefined && this.active;
  }

  processWithReplacement() {
    if (!this.ValidLicense) {
      this.notificationService.showMessage({
        message: 'You cannot replace an invalid license!',
        status: 'failed',
      });
      return;
    }
    if (this.replace_mode == enMode.lost) {
      this.licenseService
        .lostReplacement(this.current_license()!.id, this.current_user_id()!)
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
              message: 'License replaced successfully',
              status: 'success',
            });
          },
        });
    } else if (this.replace_mode == enMode.damage) {
      this.licenseService
        .damageReplacement(this.current_license()!.id, this.current_user_id()!)
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
              message: 'License replaced successfully',
              status: 'success',
            });
          },
        });
    }
  }

  onReplace() {
    if (this.replaceMode == undefined) {
      this.notificationService.showMessage({
        message: 'Please select replacement mode!',
        status: 'notification',
      });
      return;
    }
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
