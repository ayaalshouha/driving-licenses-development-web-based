import { Component, DestroyRef, inject, signal } from '@angular/core';
import { TestType } from '../../../models/test-type.model';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { TestTypesService } from '../../../services/test-type.service';
import { tap } from 'rxjs';
import { CurrencyPipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { NotificationService } from '../../../services/notification.service';
import { NotificationComponent } from '../../../shared/notification/notification.component';
import { ConfirmationDialogComponent } from '../../../shared/confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-tests',
  standalone: true,
  imports: [
    CurrencyPipe,
    ReactiveFormsModule,
    RouterLink,
    NotificationComponent,
    ConfirmationDialogComponent,
  ],
  templateUrl: './tests.component.html',
  styleUrl: './tests.component.css',
})
export class TestsComponent {
  test_id: number | null = null;
  isDialogVisible = signal<boolean>(false);
  currentPage = 1;
  pageSize = 7;
  types: TestType[] = [];
  filteredTypes: TestType[] = [];
  displayedData: TestType[] = [];
  private destroyRef = inject(DestroyRef);
  filter = new FormControl('', { nonNullable: true });

  constructor(
    private typesService: TestTypesService,
    private notifyService: NotificationService
  ) {}

  ngOnInit(): void {
    this.loadTypes();
    this.filter.valueChanges
      .pipe(tap((response) => this.applyFilter(response)))
      .subscribe();
  }

  loadTypes() {
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

  onDialogResult(confirm: boolean) {
    this.isDialogVisible.set(false);
    if (confirm) {
      if (this.test_id) {
        this.typesService.delete(this.test_id!).subscribe({
          next: () => {
            this.notifyService.showMessage({
              message: 'Test deletted successfully',
              status: 'success',
            });
            this.loadTypes();
          },
          error: (error) => {
            this.notifyService.showMessage({
              message: error.message,
              status: 'failed',
            });
          },
        });
      }
    }
  }
  onDelete(id: number) {
    this.test_id = id;
    this.isDialogVisible.set(true);
  }
}
