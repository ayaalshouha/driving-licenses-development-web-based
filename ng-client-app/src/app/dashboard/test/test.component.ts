import { Component, OnInit, signal, ViewEncapsulation } from '@angular/core';
import { TestService } from '../../services/test.service';
import { DriverService } from '../../services/driver.service';
import { LicenseService } from '../../services/license.service';
import { switchMap, tap } from 'rxjs';
import { ApplicationService } from '../../services/application.service';

@Component({
  selector: 'app-test',
  standalone: true,
  imports: [],
  templateUrl: './test.component.html',
  styleUrl: './test.component.css',
  encapsulation: ViewEncapsulation.Emulated,
})
export class TestComponent implements OnInit {
  testCount = signal<number>(0);
  driversCount = signal<number>(0);
  licensesCount = signal<number>(0);
  appsCount = signal<number>(0);

  constructor(
    private testService: TestService,
    private driverService: DriverService,
    private licenseService: LicenseService,
    private applicationService: ApplicationService
  ) {}
  ngOnInit(): void {
    this.driverService
      .count()
      .pipe(
        tap((driverCount) => this.driversCount.set(driverCount)),
        switchMap((driverCount) => {
          return this.testService.count().pipe(
            tap((testCount) => {
              this.testCount.set(testCount);
            }),
            switchMap((testCount) => {
              return this.licenseService.count().pipe(
                tap((licensesCount) => {
                  this.licensesCount.set(licensesCount);
                }),
                switchMap((licensesCount) => {
                  return this.applicationService
                    .count()
                    .pipe(tap((appsCount) => this.appsCount.set(appsCount)));
                })
              );
            })
          );
        })
      )
      .subscribe();
  }
}
