import { DatePipe } from '@angular/common';
import { Component, DestroyRef, inject } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { TestType } from '../../../models/test-type.model';
import { TestTypesService } from '../../../services/test-type.service';
import {
  catchError,
  concatMap,
  forkJoin,
  of,
  pipe,
  switchMap,
  tap,
} from 'rxjs';
import {
  LocalApplication,
  TestCount,
} from '../../../models/local-application.model';
import { LocalApplicationService } from '../../../services/local-application.service';
import {
  ApplicantName,
  Application,
  enApplicationStatus,
  enApplicationType,
} from '../../../models/application.model';
import { ApplicationService } from '../../../services/application.service';
import { PersonService } from '../../../services/person.service';
import { enLicenseClass } from '../../../models/license-class.model';
import { fork } from 'child_process';
import { pid } from 'process';
@Component({
  selector: 'app-make-appointment',
  standalone: true,
  imports: [ReactiveFormsModule, DatePipe],
  templateUrl: './make-appointment.component.html',
  styleUrl: './make-appointment.component.css',
})
export class MakeAppointmentComponent {
  current_local_application: LocalApplication | null = null;
  current_main_application: Application | null = null;
  testTypes: TestType[] = [];
  private destroRef = inject(DestroyRef);

  constructor(
    private testTypeService: TestTypesService,
    private applicationService: LocalApplicationService,
    private mainAppService: ApplicationService,
    private personService: PersonService
  ) {
    const subscription = this.testTypeService
      .all()
      .pipe(
        tap((response) => {
          this.testTypes = response;
        })
      )
      .subscribe();

    this.destroRef.onDestroy(() => subscription.unsubscribe());
  }
  filter = new FormControl('', {
    validators: [Validators.required, Validators.min(1)],
  });
  current_date = new Date();
  application_info = new FormGroup({
    applicantName: new FormControl('', {}),
    applicationType: new FormControl('', {}),
    className: new FormControl('', {}),
    status: new FormControl('', {}),
    fee: new FormControl('', {}),
    date: new FormControl('', {}),
    passedTest: new FormControl('0', {}),
    testType: new FormControl('', {}),
    schaduledDate: new FormControl(),
  });

  updateForm(
    mainApp: Application,
    applicantName: string,
    testCount: number
  ): void {
    this.application_info.patchValue({
      applicantName,
      passedTest: `${testCount}/3`,
      status: enApplicationStatus[mainApp.status],
      applicationType: enApplicationType[mainApp.type],
      fee: mainApp.paidFees.toPrecision(),
      className: enLicenseClass[this.current_local_application!.licenseClassID],
      date: mainApp.date.toISOString(),
    });
  }

  onSearch() {
    const aplicationID: number = +this.filter.value!;
    const subscription = this.applicationService
      .read(aplicationID)
      .pipe(
        tap((response) => (this.current_local_application = response)),
        switchMap((response) => {
          if (!response.id) {
            throw new Error('Invalid Local Application Data');
          }
          return this.mainAppService.read(response.applicationID);
        }),
        tap((mainApp) => (this.current_main_application = mainApp)),
        switchMap((mainApp) => {
          return forkJoin({
            applicantName: this.personService.getFullName(mainApp.personID),
            testCount: this.applicationService
              .passedTestCount(this.current_local_application!.id)
              .pipe(catchError(() => of(-1))),
            status: of(enApplicationStatus[mainApp.status]),

            applicationType: of(enApplicationType[mainApp.type]),
            fee: of(mainApp.paidFees.toPrecision()),
            className: of(
              enLicenseClass[this.current_local_application!.licenseClassID]
            ),
            date: of(mainApp.date.toISOString()),
          });
        })
      )
      .subscribe({
        next: (data) => {
          this.application_info.controls.applicantName.setValue(
            data.applicantName
          );
          this.application_info.controls.passedTest.setValue(
            `${data.testCount}/3`
          );
          this.application_info.controls.fee.setValue(data.fee);
          this.application_info.controls.date.setValue(data.date);
          this.application_info.controls.status.setValue(data.status);
          this.application_info.controls.className.setValue(data.className);
          this.application_info.controls.testType.setValue(
            data.applicationType
          );
        },
        error: (err) => {
          console.log('Error fetching data: ' + err.message);
        },
        complete: () => {
          console.log('Data fetching sequence completed');
        },
      });

    this.destroRef.onDestroy(() => subscription.unsubscribe());
  }
}
