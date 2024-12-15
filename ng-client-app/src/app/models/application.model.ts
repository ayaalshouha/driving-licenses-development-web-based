import { PersonService } from '../services/person.service';
import { tap } from 'rxjs';
import { DestroyRef, inject } from '@angular/core';

export interface Application {
  id: number;
  personID: number;
  status: enApplicationStatus;
  type: enApplicationType;
  date: Date;
  paidFees: number;
  lastStatusDate: Date;
  createdByUserID: number;
}

export enum enApplicationStatus {
  'New' = 1,
  'Cancelled',
  'Completed',
}

export enum enApplicationType {
  'New Local Driving License Services' = 1,
  'Renew Driving License Service',
  'Replacement for Lost Driving License',
  'Replacement for Damaged Driving License',
  'Release Detained Driving License',
}

export class ApplicantName {
  applicantName = '';
  private destroyRef = inject(DestroyRef);
  private personSerive = inject(PersonService);
  constructor(ID: number) {
    const subscription = this.personSerive
      .read(ID)
      .pipe(
        tap(
          (response) =>
            (this.applicantName = `${response.firstName} ${response.secondName} ${response.thirdName} ${response.lastName}`)
        )
      )
      .subscribe();

    this.destroyRef.onDestroy(() => subscription.unsubscribe());
  }
}
