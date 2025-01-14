import { Component, DestroyRef, inject, OnInit, signal } from '@angular/core';
import { ApplicationType } from '../../../models/application-type.model';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { ApplicationTypesService } from '../../../services/application-type.service';
import { tap } from 'rxjs';
import { CurrencyPipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { ConfirmationDialogComponent } from '../../../shared/confirmation-dialog/confirmation-dialog.component';
import { NotificationService } from '../../../services/notification.service';
import { NotificationComponent } from "../../../shared/notification/notification.component";

@Component({
  selector: 'app-application-types',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CurrencyPipe,
    RouterLink,
    ConfirmationDialogComponent,
    NotificationComponent
],
  templateUrl: './application-types.component.html',
  styleUrl: './application-types.component.css',
})
export class ApplicationTypesComponent implements OnInit {
  isDialogVisible = signal<boolean>(false);
  app_id: number | null = null;
  currentPage = 1;
  pageSize = 7;
  types: ApplicationType[] = [];
  filteredTypes: ApplicationType[] = [];
  displayedData: ApplicationType[] = [];
  private destroyRef = inject(DestroyRef);
  filter = new FormControl('', { nonNullable: true });

  constructor(
    private applicationtypesService: ApplicationTypesService,
    private notifyService: NotificationService
  ) {}

  ngOnInit(): void {
    this.loadTypes();
    this.filter.valueChanges
      .pipe(tap((response) => this.applyFilter(response)))
      .subscribe();
  }

  loadTypes() {
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
  onDialogResult(confirm: boolean) {
    this.isDialogVisible.set(false);
    if (confirm) {
      if (this.app_id) {
        this.applicationtypesService.delete(this.app_id!).subscribe({
          next: () => {
            this.notifyService.showMessage({
              message: 'Application deletted successfully',
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
    this.app_id = id;
    this.isDialogVisible.set(true);
  }
  onPrevious() {
    if ((this, this.currentPage > 1)) {
      this.currentPage--;
      this.updateDisplayedData();
    }
  }
}
