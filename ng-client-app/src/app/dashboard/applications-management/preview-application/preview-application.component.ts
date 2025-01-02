import {
  Component,
  Inject,
  OnDestroy,
  OnInit,
  PLATFORM_ID,
  signal,
} from '@angular/core';
import { DialogWrapperComponent } from '../../../shared/dialog-wrapper/dialog-wrapper.component';
import { LocalApplicationView } from '../../../models/local-application.model';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { isPlatformBrowser, Location } from '@angular/common';
import { LocalApplicationService } from '../../../services/local-application.service';
import { catchError, Subject, takeUntil, tap, throwError } from 'rxjs';
import { NotificationService } from '../../../services/notification.service';
import { NotificationComponent } from '../../../shared/notification/notification.component';
import { ConfirmationDialogComponent } from '../../../shared/confirmation-dialog/confirmation-dialog.component';
@Component({
  selector: 'app-preview-application',
  standalone: true,
  imports: [
    RouterLink,
    DialogWrapperComponent,
    NotificationComponent,
    ConfirmationDialogComponent,
  ],
  templateUrl: './preview-application.component.html',
  styleUrl: './preview-application.component.css',
})
export class PreviewApplicationComponent implements OnInit, OnDestroy {
  isDialogVisible = signal<boolean>(false);
  licese_id = signal<number | undefined>(undefined);
  current_user_id = signal<number | undefined>(undefined);
  application_id: number | null = null;
  licenseIssued = signal<boolean>(false);
  current_application: LocalApplicationView | undefined = undefined;
  private destroy$ = new Subject<void>();
  constructor(
    @Inject(PLATFORM_ID) private platformId: Object,
    private route: ActivatedRoute,
    private location: Location,
    private localAppServ: LocalApplicationService,
    private notifyServ: NotificationService
  ) {}
  ngOnInit(): void {
    this.route.queryParams.subscribe(
      (params) => (this.application_id = +params['application_id'])
    );
    this.retrieveApplicationData();
    this.checkLicenseIssuance();

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
  }

  retrieveApplicationData() {
    console.log('from preview application id = ' + this.application_id);
    if (this.application_id) {
      this.localAppServ
        .readView(this.application_id)
        .pipe(
          catchError((error) => throwError(() => new Error(error))),
          tap((local_app) => {
            this.current_application = local_app;
          }),
          takeUntil(this.destroy$)
        )
        .subscribe({
          error: (error) => {
            this.notifyServ.showMessage({
              message: error.message,
              status: 'failed',
            });
          },
        });
    }
  }

  checkLicenseIssuance() {
    this.localAppServ
      .licenseID(this.application_id!)
      .pipe(
        catchError((error) => throwError(() => new Error(error))),
        tap((liceseID) => {
          if (liceseID > 0) {
            this.licese_id.set(liceseID);
            this.licenseIssued.set(true);
          }
        })
      )
      .subscribe({
        error: (error) => {
          this.notifyServ.showMessage({
            message: error.messages,
            status: 'failed',
          });
        },
      });
  }
  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
  onClose() {
    this.location.back();
  }

  issueLicenseFirsttime() {
    this.isDialogVisible.set(true);
  }

  issuanceProcess() {
    console.log('application id ' + this.application_id);
    this.localAppServ
      .issueLicenseFisrTime(this.application_id!, this.current_user_id()!, null)
      .pipe(
        catchError((error) => throwError(() => new Error(error.message))),
        tap((new_license_id) => {
          if (new_license_id > 0) {
            this.licese_id.set(new_license_id);
            this.licenseIssued.set(true);
          }
        })
      )
      .subscribe({
        next: () => {
          this.notifyServ.showMessage({
            message: `License issued successfully, New license ID is ${this.licese_id()}`,
            status: 'success',
          });
        },
        error: (error) => {
          this.notifyServ.showMessage({
            message: error.message,
            status: 'failed',
          });
        },
      });
  }

  onDialogResult(confirmed: boolean) {
    if (confirmed) {
      this.issuanceProcess();
    }
    this.isDialogVisible.set(false);
  }
}
