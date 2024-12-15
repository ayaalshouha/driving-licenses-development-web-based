import { DatePipe } from '@angular/common';
import { Component, computed, DestroyRef, inject } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { TestType } from '../../../models/test-type.model';
import { TestTypesService } from '../../../services/test-type.service';
import { concatMap, switchMap, tap, throwError } from 'rxjs';
import {
  LocalApplication,
  TestCount,
} from '../../../models/local-application.model';
import { LocalApplicationService } from '../../../services/local-application.service';
import { ApplicationType } from '../../../models/application-type.model';
import {
  ApplicantName,
  Application,
  enApplicationStatus,
  enApplicationType,
} from '../../../models/application.model';
import { ApplicationService } from '../../../services/application.service';
import { PersonService } from '../../../services/person.service';
import { stat } from 'fs';
import { enLicenseClass } from '../../../models/license-class.model';
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
    private mainAppService: ApplicationService
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
        tap((response) => {
          this.current_main_application = response;
          if (!response.id) {
            throw new Error('Invalid Application Data');
          } else {
            const fullName = new ApplicantName(
              this.current_main_application.personID
            ).applicantName;
            const testCount = new TestCount(this.current_local_application!.id)
              .passedTestCount;

            this.application_info.controls.applicantName.setValue(fullName);
            this.application_info.controls.passedTest.setValue(
              `${testCount}/3`
            );
            this.application_info.controls.status.setValue(
              enApplicationStatus[this.current_main_application.status]
            );
            this.application_info.controls.applicationType.setValue(
              enApplicationType[this.current_main_application.type]
            );
            this.application_info.controls.fee.setValue(
              this.current_main_application.paidFees.toPrecision()
            );
            this.application_info.controls.className.setValue(
              enLicenseClass[this.current_local_application!.licenseClassID]
            );
            this.application_info.controls.date.setValue(
              this.current_main_application.date.toISOString()
            );
          }
        })
      )
      .subscribe({
        error: (err) => {
          console.log('error fetching data ' + err.message);
        },
      });
  }
}
