import { Component, DestroyRef, inject } from '@angular/core';
import { DetainedLicense } from '../../../models/detained-license.model';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { DetainedLicenseService } from '../../../services/detained-license.service';
import { tap } from 'rxjs';
import { CurrencyPipe, DatePipe } from '@angular/common';

@Component({
  selector: 'app-detained-licenses',
  standalone: true,
  imports: [ReactiveFormsModule, DatePipe, CurrencyPipe],
  templateUrl: './detained-licenses.component.html',
  styleUrl: './detained-licenses.component.css',
})
export class DetainedLicensesComponent {
  currentPage = 1;
  pageSize = 6;
  list: DetainedLicense[] = [];
  dataDisplayed: DetainedLicense[] = [];
  private destroyRef = inject(DestroyRef);
  filter = new FormControl('', { nonNullable: true });

  constructor(private licenseService: DetainedLicenseService) {}

  ngOnInit(): void {
    const subscription = this.licenseService
      .all()
      .pipe(
        tap((response) => {
          this.list = response;
          this.updateDisplayedData(0);
        })
      )
      .subscribe();

    this.destroyRef.onDestroy(() => subscription.unsubscribe());
  }

  updateDisplayedData(startIndex: number = 0) {
    const endIndex = startIndex + this.pageSize;
    this.dataDisplayed = this.list.slice(startIndex, endIndex);
  }
  onNext() {
    if (this.currentPage * this.pageSize < this.list.length) {
      this.currentPage++;
      this.updateDisplayedData((this.currentPage - 1) * this.pageSize);
    }
  }
  onPrevious() {
    this.currentPage--;
    this.updateDisplayedData((this.currentPage - 1) * this.pageSize);
  }
}
