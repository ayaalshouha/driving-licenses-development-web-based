import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Subject } from 'rxjs';
import { DriverService } from '../../../../services/driver.service';
import { Driver_View } from '../../../../models/driver.model';
import { NotificationService } from '../../../../services/notification.service';
import { ConfirmationDialogComponent } from '../../../../shared/confirmation-dialog/confirmation-dialog.component';
import { NotificationComponent } from '../../../../shared/notification/notification.component';
import { DialogWrapperComponent } from '../../../../shared/dialog-wrapper/dialog-wrapper.component';
import { Location } from '@angular/common';

@Component({
  selector: 'app-preview-driver',
  standalone: true,
  imports: [NotificationComponent, DialogWrapperComponent, RouterLink],
  templateUrl: './preview-driver.component.html',
  styleUrl: './preview-driver.component.css',
})
export class PreviewDriverComponent implements OnInit {
  driver_id: number | undefined = undefined;
  current_driver: Driver_View | undefined = undefined;
  destroy$ = new Subject<void>();
  constructor(
    private route: ActivatedRoute,
    private driverService: DriverService,
    private notufyServ: NotificationService,
    private location: Location
  ) {}
  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.driver_id = params['id'];
    });

    if (this.driver_id) {
      this.loadData();
    }
  }

  loadData() {
    this.driverService.read(this.driver_id!).subscribe(
      (data) => {
        this.current_driver = data;
      },
      (error) => {
        this.notufyServ.showMessage({
          message: error.message,
          status: 'failed',
        });
      }
    );
  }
  onClose() {
    this.location.back();
  }
}
