import { Component, DestroyRef, inject } from '@angular/core';
import { License, ShortLicense } from '../../../../../models/license.model';
import { Driver_View } from '../../../../../models/driver.model';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { LicenseService } from '../../../../../services/license.service';
import { NotificationService } from '../../../../../services/notification.service';
import { DriverService } from '../../../../../services/driver.service';
import { switchMap, tap } from 'rxjs';
import { DatePipe, Location } from '@angular/common';
import { NotificationComponent } from '../../../../../shared/notification/notification.component';
import { DialogWrapperComponent } from '../../../../../shared/dialog-wrapper/dialog-wrapper.component';
@Component({
  selector: 'app-preview-license',
  standalone: true,
  imports: [
    NotificationComponent,
    DialogWrapperComponent,
    DatePipe,
    RouterLink,
  ],
  templateUrl: './preview-license.component.html',
  styleUrl: './preview-license.component.css',
})
export class PreviewLicenseComponent {
  licenseID: number | null = null;
  current_license: License | undefined = undefined;
  current_driver: Driver_View | undefined = undefined;
  private destroyRef = inject(DestroyRef);
  constructor(
    private location: Location,
    private route: ActivatedRoute,
    private licenseService: LicenseService,
    private driverService: DriverService,
    private notifyServ: NotificationService
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.licenseID = params['id'];
    });

    this.loadTest();
  }

  loadTest() {
    if (this.licenseID) {
      const subscription = this.licenseService
        .read(this.licenseID!)
        .pipe(
          tap((response) => {
            if (response) {
              this.current_license = response;
            }
          }),
          switchMap((response) => {
            return this.driverService
              .read(response.driverID)
              .pipe(tap((response) => (this.current_driver = response)));
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

  onClose() {
    this.location.back();
  }
}
