import { Component, DestroyRef, inject } from '@angular/core';
import { TestType } from '../../../models/test-type.model';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { TestTypesService } from '../../../services/test-type.service';
import { tap } from 'rxjs';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-tests',
  standalone: true,
  imports: [CurrencyPipe, ReactiveFormsModule],
  templateUrl: './tests.component.html',
  styleUrl: './tests.component.css',
})
export class TestsComponent {
  currentPage = 1;
  pageSize = 7;
  types: TestType[] = [];
  filteredTypes: TestType[] = [];
  displayedData: TestType[] = [];
  private destroyRef = inject(DestroyRef);
  filter = new FormControl('', { nonNullable: true });

  constructor(private typesService: TestTypesService) {}

  ngOnInit(): void {
    const subscription = this.typesService
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
