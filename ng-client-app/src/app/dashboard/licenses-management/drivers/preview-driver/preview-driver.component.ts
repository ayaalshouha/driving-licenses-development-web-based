import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs';
import { DriverService } from '../../../../services/driver.service';
import { Driver, Driver_View } from '../../../../models/driver.model';
import { error } from 'console';
import { NotificationService } from '../../../../services/notification.service';

@Component({
  selector: 'app-preview-driver',
  standalone: true,
  imports: [],
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
    private notufyServ: NotificationService
  ) {}
  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.driver_id = params['id'];
    });

    if (this.driver_id) {
      //retrieving driver id
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
}
