import { CurrencyPipe, DatePipe } from '@angular/common';
import { Component, signal } from '@angular/core';
import { FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { TestType } from '../../../models/test-type.model';
import { TestTypesService } from '../../../services/test-type.service';
import { forkJoin, Subject, switchMap, takeUntil, tap, throwError } from 'rxjs';
import { LocalApplication } from '../../../models/local-application.model';
import { LocalApplicationService } from '../../../services/local-application.service';
import {
  Application,
  enApplicationStatus,
  enApplicationType,
} from '../../../models/application.model';
import { ApplicationService } from '../../../services/application.service';
import { PersonService } from '../../../services/person.service';
import { enLicenseClass } from '../../../models/license-class.model';
@Component({
  selector: 'app-make-appointment',
  standalone: true,
  imports: [ReactiveFormsModule, DatePipe, CurrencyPipe],
  templateUrl: './make-appointment.component.html',
  styleUrl: './make-appointment.component.css',
})
export class MakeAppointmentComponent {
  current_local_application: LocalApplication | null = null;
  current_main_application: Application | null = null;
  applicantName = signal<string>('');
  testCount = signal<number>(0);
  applicationType = signal<string | undefined>(undefined);
  applicationStatus = signal<string | undefined>(undefined);
  licenseClass = signal<string | undefined>(undefined);
  testTypeFee = signal<number | undefined>(undefined);
  filter = new FormControl('', {
    validators: [Validators.required, Validators.min(1)],
  });
  current_date = new Date();
  testTypes: TestType[] = [];
  private destroy$ = new Subject<void>();

  constructor(
    private testTypeService: TestTypesService,
    private applicationService: LocalApplicationService,
    private mainAppService: ApplicationService,
    private personService: PersonService
  ) {
    this.testTypeService
      .all()
      .pipe(
        tap((response) => {
          this.testTypes = response;
        }),
        takeUntil(this.destroy$)
      )
      .subscribe();
  }

  onSearch() {
    const applicationID: number = +this.filter.value!;

    this.applicationService
      .read(applicationID)
      .pipe(
        switchMap((localApp) => {
          if (!localApp.id)
            return throwError(
              () => new Error('Invalid Local Application Data')
            );
          this.current_local_application = localApp;

          return this.mainAppService.read(localApp.applicationID).pipe(
            switchMap((mainApp) => {
              if (!mainApp.id)
                return throwError(
                  () => new Error('Invalid Main Application Data')
                );
              this.current_main_application = mainApp;

              this.applicationStatus.set(
                enApplicationStatus[this.current_main_application.status]
              );

              this.applicationType.set(
                enApplicationType[this.current_main_application.type]
              );
              this.licenseClass.set(
                enLicenseClass[this.current_local_application!.licenseClassID]
              );

              return forkJoin({
                passedTest: this.applicationService.passedTestCount(
                  localApp.id
                ),
                applicantFullName: this.personService.getFullName(
                  mainApp.personID
                ),
              });
            })
          );
        }),
        takeUntil(this.destroy$) // Automatic cleanup
      )
      .subscribe({
        next: ({ passedTest, applicantFullName }) => {
          this.testCount.set(passedTest);
          this.applicantName.set(applicantFullName);
          console.log('Passed Test Count: ' + this.testCount());
        },
        error: (err) => {
          console.error('Error fetching data:', err.message);
        },
        complete: () => {
          console.log('Data fetching sequence completed');
        },
      });
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
