import { PersonService } from '../services/person.service';
import { tap } from 'rxjs';
import { DestroyRef, inject } from '@angular/core';

export interface Application {
  id: number;
  personID: number;
  status: 1 | 2 | 3;
  type: number;
  date: Date;
  paidFees: number;
  lastStatusDate: Date;
  createdByUserID: number;
}

export enum ApplicationStatus {
  'New' = 1,
  'Cancelled',
  'Completed',
}

export class ApplicantName {
  applicantName = '';
  private destroyRef = inject(DestroyRef);
  constructor(ID: number, private personSerice: PersonService) {
    const subscription = this.personSerice
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
