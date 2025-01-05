import { Component, OnDestroy, OnInit } from '@angular/core';
import { DialogWrapperComponent } from '../../../../shared/dialog-wrapper/dialog-wrapper.component';
import { ActivatedRoute } from '@angular/router';
import { PersonService } from '../../../../services/person.service';
import { Person } from '../../../../models/person.model';
import { NotificationService } from '../../../../services/notification.service';
import { Driver, Driver_View } from '../../../../models/driver.model';
import { DriversComponent } from '../drivers.component';
import { DriverService } from '../../../../services/driver.service';
import { License, ShortLicense } from '../../../../models/license.model';
import { ShortInternationalLicense } from '../../../../models/internationl-license.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-licenses-history',
  standalone: true,
  imports: [DialogWrapperComponent],
  templateUrl: './licenses-history.component.html',
  styleUrl: './licenses-history.component.css',
})
export class LicensesHistoryComponent implements OnInit, OnDestroy {
  id: number | undefined = undefined;
  current_driver: Driver_View | undefined = undefined;
  localLicenses: ShortLicense[] | undefined = [];
  internationalLicenses: ShortInternationalLicense[] | undefined = [];
  subscriptions: Subscription[] = [];
  constructor(
    private route: ActivatedRoute,
    private driverServ: DriverService,
    private noifyServ: NotificationService
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
    const subscription = this.driverServ.read(this.id!).subscribe({
      next: (data) => {
        this.current_driver = data;
      },
      error: (error) => {
        this.noifyServ.showMessage({
          message: error.message,
          status: 'failed',
        });
      },
    });
    this.subscriptions.push(subscription);
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach((sub) => sub.unsubscribe());
  }
}
