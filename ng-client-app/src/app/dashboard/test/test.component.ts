import {
  Component,
  OnDestroy,
  OnInit,
  signal,
  ViewEncapsulation,
} from '@angular/core';
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
export class TestComponent implements OnInit, OnDestroy {
  testCount = signal<number>(0);
  driversCount = signal<number>(0);
  licensesCount = signal<number>(0);
  appsCount = signal<number>(0);
  malePercentage = 0;
  femalePercentage = 0;
  passedTestsPercentage = 0;
  failedTestPercentage = 0;
  private destroy$ = new Subject<void>();
  constructor(
    private testService: TestService,
    private driverService: DriverService,
    private licenseService: LicenseService,
    private applicationService: ApplicationService,
    private personService: PersonService
  ) {}

  private animateCount(target: number, signal: any, delay: number = 50) {
    const interval = setInterval(() => {
      if (signal() < target) {
        signal.update((current: number) => current + 1);
      } else {
        clearInterval(interval);
      }
    }, delay);
  }

  ngOnInit(): void {
    this.driverService
      .count()
      .pipe(
        tap((driverCount) => this.animateCount(driverCount, this.driversCount)),
        switchMap(() => {
          return this.testService.count().pipe(
            tap((testCount) => this.animateCount(testCount, this.testCount)),
            switchMap(() => {
              return this.licenseService.count().pipe(
                tap((licensesCount) =>
                  this.animateCount(licensesCount, this.licensesCount)
                ),
                switchMap(() => {
                  return this.applicationService
                    .count()
                    .pipe(
                      tap((appsCount) =>
                        this.animateCount(appsCount, this.appsCount)
                      )
                    );
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
