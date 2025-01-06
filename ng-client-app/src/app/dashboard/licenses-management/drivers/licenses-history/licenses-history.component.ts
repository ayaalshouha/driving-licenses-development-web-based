import { Component, OnDestroy, OnInit } from '@angular/core';
import { DialogWrapperComponent } from '../../../../shared/dialog-wrapper/dialog-wrapper.component';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { NotificationService } from '../../../../services/notification.service';
import { Driver_View } from '../../../../models/driver.model';
import { DriverService } from '../../../../services/driver.service';
import { ShortLicense } from '../../../../models/license.model';
import { ShortInternationalLicense } from '../../../../models/internationl-license.model';
import { forkJoin, Subscription, switchMap, tap } from 'rxjs';
import { FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { Location } from '@angular/common';
@Component({
  selector: 'app-licenses-history',
  standalone: true,
  imports: [DialogWrapperComponent, ReactiveFormsModule, RouterLink],
  templateUrl: './licenses-history.component.html',
  styleUrl: './licenses-history.component.css',
})
export class LicensesHistoryComponent implements OnInit, OnDestroy {
  id: number | undefined = undefined;
  current_driver: Driver_View | undefined = undefined;
  localLicenses: ShortLicense[] | undefined = [];
  internationalLicenses: ShortInternationalLicense[] | undefined = [];
  subscriptions: Subscription[] = [];
  app_id: number | undefined = undefined;
  licenses = new FormControl<'local' | 'international'>('local', {
    validators: Validators.required,
  });
  constructor(
    private route: ActivatedRoute,
    private driverServ: DriverService,
    private noifyServ: NotificationService,
    private location: Location
  ) {}
  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.id = +params['id'];
    });

    if (this.id) {
      this.getDriver();
    }
  }
  getDriver() {
    const subscription = this.driverServ
      .read(this.id!)
      .pipe(
        tap((driver) => {
          if (driver) {
            this.current_driver = driver;
          }
        }),
        switchMap(() => {
          return forkJoin({
            local_licenses: this.driverServ.localLicenses(
              this.current_driver!.id
            ),
            international_licenses: this.driverServ.internationalLicenses(
              this.current_driver!.id
            ),
          });
        })
      )
      .subscribe({
        next: ({ local_licenses, international_licenses }) => {
          (this.localLicenses = local_licenses),
            (this.internationalLicenses = international_licenses);
          this.app_id = this.localLicenses[0].applicationID;
        },
      });
    this.subscriptions.push(subscription);
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach((sub) => sub.unsubscribe());
  }

  onCancel() {
    this.location.back();
  }
}
