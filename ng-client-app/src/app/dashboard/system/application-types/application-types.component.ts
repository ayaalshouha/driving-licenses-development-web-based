import { Component, DestroyRef, inject, OnInit } from '@angular/core';
import { ApplicationType } from '../../../models/application-type.model';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { ApplicationTypesService } from '../../../services/application-type.service';
import { tap } from 'rxjs';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-application-types',
  standalone: true,
  imports: [ReactiveFormsModule, CurrencyPipe],
  templateUrl: './application-types.component.html',
  styleUrl: './application-types.component.css',
})
export class ApplicationTypesComponent implements OnInit {
  currentPage = 1;
  pageSize = 7;
  types: ApplicationType[] = [];
  filteredTypes: ApplicationType[] = [];
  displayedData: ApplicationType[] = [];
  private destroyRef = inject(DestroyRef);
  filter = new FormControl('', { nonNullable: true });

  constructor(private applicationtypesService: ApplicationTypesService) {}

  ngOnInit(): void {
    const subscription = this.applicationtypesService
      .all()
      .pipe(
        tap((response) => {
          this.types = response;
          this.filteredTypes = response;
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
    this.filteredTypes = this.types.filter((item) =>
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
    this.displayedData = this.filteredTypes.slice(startIndex, endIndex);
  }
  onNext() {
    if (this.currentPage * this.pageSize < this.types.length) {
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
