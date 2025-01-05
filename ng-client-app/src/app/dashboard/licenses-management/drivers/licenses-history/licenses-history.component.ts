import { Component, OnInit } from '@angular/core';
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

@Component({
  selector: 'app-licenses-history',
  standalone: true,
  imports: [DialogWrapperComponent],
  templateUrl: './licenses-history.component.html',
  styleUrl: './licenses-history.component.css',
})
export class LicensesHistoryComponent implements OnInit {
  id: number | undefined = undefined;
  current_driver: Driver_View | undefined = undefined;
  localLicenses: ShortLicense[] | undefined = [];
  internationalLicenses: ShortInternationalLicense[] | undefined = [];

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
    this.driverServ.read(this.id!).subscribe(
      (data) => {
        this.current_driver = data;
      },
      (error) => {
        this.noifyServ.showMessage({
          message: error.message,
          status: 'failed',
        });
      }
    );
  }
}
