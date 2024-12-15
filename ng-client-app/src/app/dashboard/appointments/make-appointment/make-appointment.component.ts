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
import { LocalApplication } from '../../../models/local-application.model';
import { LocalApplicationService } from '../../../services/local-application.service';
import { ApplicationType } from '../../../models/application-type.model';
import { Application } from '../../../models/application.model';
import { ApplicationService } from '../../../services/application.service';
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
    passedTest: new FormControl('', {}),
    testType: new FormControl('', {}),
    schaduledDate: new FormControl(),
  });

  onSearch() {
    if (this.filter.valid) {
      const aplicationID: number = +this.filter.value!;
      const licenseClass = '';
      const applicantName = '';
      const status = 1;

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
          concatMap((response) => {
            this.application_info.controls.className.value =
              this.current_local_application?.licenseClassID;
          })
        )
        .subscribe();
    }
  }
}
