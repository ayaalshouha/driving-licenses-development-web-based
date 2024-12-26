import { Component, OnInit, signal, ViewEncapsulation } from '@angular/core';
import { TestService } from '../../services/test.service';
import { DriverService } from '../../services/driver.service';
import { LicenseService } from '../../services/license.service';
import { forkJoin, Subject, switchMap, takeUntil, tap } from 'rxjs';
import { ApplicationService } from '../../services/application.service';
import { CommonModule } from '@angular/common';
import { PersonService } from '../../services/person.service';

@Component({
  selector: 'app-test',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './test.component.html',
  styleUrl: './test.component.css',
  encapsulation: ViewEncapsulation.Emulated,
})
export class TestComponent implements OnInit {
  testCount = signal<number>(0);
  driversCount = signal<number>(0);
  licensesCount = signal<number>(0);
  appsCount = signal<number>(0);
  malePercentage = 0;
  femalePercentage = 0;
  private destroy$ = new Subject<void>();
  constructor(
    private testService: TestService,
    private driverService: DriverService,
    private licenseService: LicenseService,
    private applicationService: ApplicationService,
    private personService: PersonService
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
        }),

        takeUntil(this.destroy$)
      )
      .subscribe();

    forkJoin({
      maleCount: this.personService
        .malePercentage()
        .pipe(takeUntil(this.destroy$)),
      femaleCount: this.personService
        .femlePercentage()
        .pipe(takeUntil(this.destroy$)),
    }).subscribe(({ maleCount, femaleCount }) => {
      this.malePercentage = maleCount;
      this.femalePercentage = femaleCount;
    });
  }
  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
