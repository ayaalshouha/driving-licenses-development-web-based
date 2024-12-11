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
  dataDisplayed: InternationalLicense[] = [];
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
          this.updateDisplayedData(0);
        })
      )
      .subscribe();

    this.destroyRef.onDestroy(() => subscription.unsubscribe());
  }

  updateDisplayedData(startIndex: number = 0) {
    const endIndex = startIndex + this.pageSize;
    this.dataDisplayed = this.licenses.slice(startIndex, endIndex);
  }
  onNext() {
    if (this.currentPage * this.pageSize < this.licenses.length) {
      this.currentPage++;
      this.updateDisplayedData((this.currentPage - 1) * this.pageSize);
    }
  }
  onPrevious() {
    this.currentPage--;
    this.updateDisplayedData((this.currentPage - 1) * this.pageSize);
  }
}
