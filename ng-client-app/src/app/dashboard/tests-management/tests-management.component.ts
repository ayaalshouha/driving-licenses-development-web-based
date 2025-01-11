import { Component, DestroyRef, inject } from '@angular/core';
import { Test } from '../../models/test.model';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { TestService } from '../../services/test.service';
import { tap } from 'rxjs';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-tests-management',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './tests-management.component.html',
  styleUrl: './tests-management.component.css',
})
export class TestsManagementComponent {
  currentPage = 1;
  pageSize = 5;
  tests: Test[] = [];
  filteredTests: Test[] = [];
  displayedData: Test[] = [];
  private destroyRef = inject(DestroyRef);
  filter = new FormControl('', { nonNullable: true });

  constructor(private testService: TestService) {}

  ngOnInit(): void {
    const subscription = this.testService
      .all()
      .pipe(
        tap((response) => {
          this.tests = response;
          this.filteredTests = response;
          this.updateDisplayedData();
        })
      )
      .subscribe();

    this.destroyRef.onDestroy(() => subscription.unsubscribe());
    this.filter.valueChanges
      .pipe(
        tap((value) => {
          this.applyFilter(value);
        })
      )
      .subscribe();
  }

  applyFilter(value: string) {
    const lowerCaseFilter = value.toLowerCase();
    this.filteredTests = this.tests.filter((item) =>
      Object.values(item).some((val) =>
        String(val).toLowerCase().includes(lowerCaseFilter)
      )
    );
    this.currentPage = 1;
    this.updateDisplayedData();
  }

  updateDisplayedData() {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    this.displayedData = this.filteredTests.slice(startIndex, endIndex);
  }
  onNext() {
    if (this.currentPage * this.pageSize < this.filteredTests.length) {
      this.currentPage++;
      this.updateDisplayedData();
    }
  }
  onPrevious() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.updateDisplayedData();
    }
  }
}
