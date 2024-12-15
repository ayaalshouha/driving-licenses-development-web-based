import { DestroyRef, inject } from '@angular/core';
import { LocalApplicationService } from '../services/local-application.service';
import { tap } from 'rxjs';

export interface LocalApplication {
  id: number;
  applicationID: number;
  licenseClassID: number;
}

export interface LocalApplicationView {
  id: number;
  nationalID: string;
  class: string;
  fullName: string;
  date: string;
  passedTest: number;
  status: string;
}

export class TestCount {
  passedTestCount = 0;
  private destroyRef = inject(DestroyRef);
  private localAppService = inject(LocalApplicationService);
  constructor(application_id: number) {
    const subscription = this.localAppService
      .passedTestCount(application_id)
      .pipe(tap((val) => (this.passedTestCount = val)))
      .subscribe();

    this.destroyRef.onDestroy(() => subscription.unsubscribe());
  }
}
