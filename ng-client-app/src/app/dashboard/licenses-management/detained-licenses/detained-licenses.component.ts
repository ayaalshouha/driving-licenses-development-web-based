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
  filteredList: DetainedLicense[] = [];
  displayedData: DetainedLicense[] = [];
  private destroyRef = inject(DestroyRef);
  filter = new FormControl('', { nonNullable: true });

  constructor(private licenseService: DetainedLicenseService) {}

  ngOnInit(): void {
    const subscription = this.licenseService
      .all()
      .pipe(
        tap((response) => {
          this.list = response;
          this.filteredList = response;
          this.updateDisplayedData();
        })
      )
      .subscribe();

    this.destroyRef.onDestroy(() => subscription.unsubscribe());

    this.filter.valueChanges
      .pipe(tap((response) => this.applyFilter(response)))
      .subscribe();
  }

  applyFilter(value: string) {
    const lowerCaseValue = value;
    this.filteredList = this.list.filter((item) =>
      Object.values(item).some((val) =>
        String(val).toLowerCase().includes(lowerCaseValue)
      )
    );
    this.currentPage = 1;
    this.updateDisplayedData();
  }
  updateDisplayedData() {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    this.displayedData = this.filteredList.slice(startIndex, endIndex);
  }
  onNext() {
    if (this.currentPage * this.pageSize < this.list.length) {
      this.currentPage++;
      this.updateDisplayedData();
    }
  }
  onPrevious() {
    if ((this, this.currentPage > 1)) {
      this.currentPage--;
      this.updateDisplayedData();
    }
  }
}
