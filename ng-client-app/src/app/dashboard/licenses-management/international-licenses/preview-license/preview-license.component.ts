import { Component, DestroyRef, inject } from '@angular/core';
import { InternationalLicense } from '../../../../models/internationl-license.model';
import { ActivatedRoute } from '@angular/router';
import { InternationlLicenseService } from '../../../../services/international-license.service';
import { NotificationService } from '../../../../services/notification.service';
import { switchMap, tap } from 'rxjs';
import { DriverService } from '../../../../services/driver.service';
import { Driver_View } from '../../../../models/driver.model';
import { DatePipe, Location } from '@angular/common';
import { NotificationComponent } from '../../../../shared/notification/notification.component';
import { DialogWrapperComponent } from '../../../../shared/dialog-wrapper/dialog-wrapper.component';
@Component({
  selector: 'app-preview-license',
  standalone: true,
  imports: [NotificationComponent, DialogWrapperComponent, DatePipe],
  templateUrl: './preview-license.component.html',
  styleUrl: './preview-license.component.css',
})
export class PreviewLicenseComponent {
  licenseID: number | null = null;
  current_license: InternationalLicense | undefined = undefined;
  current_driver: Driver_View | undefined = undefined;
  private destroyRef = inject(DestroyRef);
  constructor(
    private location: Location,
    private route: ActivatedRoute,
    private internationLicenseServ: InternationlLicenseService,
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
      const subscription = this.internationLicenseServ
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
