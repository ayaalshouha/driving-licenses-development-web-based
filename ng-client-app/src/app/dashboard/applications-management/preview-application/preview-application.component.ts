import { Component, OnDestroy, OnInit } from '@angular/core';
import { DialogWrapperComponent } from '../../../shared/dialog-wrapper/dialog-wrapper.component';
import { LocalApplicationView } from '../../../models/local-application.model';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Location } from '@angular/common';
import { LocalApplicationService } from '../../../services/local-application.service';
import { catchError, Subject, takeUntil, tap, throwError } from 'rxjs';
import { NotificationService } from '../../../services/notification.service';
@Component({
  selector: 'app-preview-application',
  standalone: true,
  imports: [RouterLink, DialogWrapperComponent],
  templateUrl: './preview-application.component.html',
  styleUrl: './preview-application.component.css',
})
export class PreviewApplicationComponent implements OnInit, OnDestroy {
  application_id: number | null = null;
  licenseIssued: boolean | undefined = undefined;
  current_application: LocalApplicationView | undefined = undefined;
  private destroy$ = new Subject<void>();
  constructor(
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
      .isLicenseIssued(this.application_id!)
      .pipe(
        catchError((error) => throwError(() => new Error(error))),
        tap((isLicenseIssued) => {
          this.licenseIssued = isLicenseIssued;
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
}
