import { Component, DestroyRef, inject } from '@angular/core';
import { InternationalLicense } from '../../../models/internationl-license.model';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { InternationlLicenseService } from '../../../services/international-license.service';
import { tap } from 'rxjs';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-international-licenses',
  standalone: true,
  imports: [ReactiveFormsModule, DatePipe],
  templateUrl: './international-licenses.component.html',
  styleUrl: './international-licenses.component.css',
})
export class InternationalLicensesComponent {
  currentPage = 1;
  pageSize = 5;
  licenses: InternationalLicense[] = [];
  filteredLicenses: InternationalLicense[] = [];
  displayedData: InternationalLicense[] = [];
  private destroyRef = inject(DestroyRef);
  filter = new FormControl('', { nonNullable: true });

  constructor(
    private internationalLicenseService: InternationlLicenseService
  ) {}

  ngOnInit(): void {
    const subscription = this.internationalLicenseService
      .all()
      .pipe(
        tap((response) => {
          this.licenses = response;
          this.filteredLicenses = response;
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
  this.filteredLicenses = this.licenses.filter((item) =>
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
  this.displayedData = this.filteredLicenses.slice(startIndex, endIndex);
}
onNext() {
  if (this.currentPage * this.pageSize < this.licenses.length) {
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
