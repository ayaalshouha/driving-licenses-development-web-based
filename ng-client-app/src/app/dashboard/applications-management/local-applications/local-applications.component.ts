import { Component, DestroyRef, inject, OnInit, signal } from '@angular/core';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { catchError, tap, throwError } from 'rxjs';
import { LocalApplicationView } from '../../../models/local-application.model';
import { LocalApplicationService } from '../../../services/local-application.service';
import { RouterLink } from '@angular/router';
import { ConfirmationDialogComponent } from '../../../shared/confirmation-dialog/confirmation-dialog.component';
import { NotificationService } from '../../../services/notification.service';
import { NotificationComponent } from '../../../shared/notification/notification.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-local-applications',
  standalone: true,
  imports: [
    RouterLink,
    ReactiveFormsModule,
    ConfirmationDialogComponent,
    NotificationComponent,
  ],
  templateUrl: './local-applications.component.html',
  styleUrl: './local-applications.component.css',
})
export class LocalApplicationsComponent implements OnInit {
  current_app_id: number | null = null;
  currentPage = 1;
  pageSize = 5;
  applications: LocalApplicationView[] = [];
  filteredApplications: LocalApplicationView[] = [];
  displayedData: LocalApplicationView[] = [];
  private destroyRef = inject(DestroyRef);
  filter = new FormControl('', { nonNullable: true });
  isDialogVisible = signal<boolean>(false);
  constructor(
    private localAppService: LocalApplicationService,
    private notifyServ: NotificationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const subscription = this.localAppService
      .getAll()
      .pipe(
        tap((response) => {
          this.applications = response;
          this.filteredApplications = response;
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
    this.filteredApplications = this.applications.filter((item) =>
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
    this.displayedData = this.filteredApplications.slice(startIndex, endIndex);
  }
  onNext() {
    if (this.currentPage * this.pageSize < this.filteredApplications.length) {
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

  onDialogResult(isConfirmed: boolean) {
    if (isConfirmed && this.current_app_id !== null) {
      const subscription = this.localAppService
        .cancel(this.current_app_id)
        .pipe(catchError((error) => throwError(() => new Error(error))))
        .subscribe({
          next: () => {
            this.notifyServ.showMessage({
              message: 'Application cancelled successfully',
              status: 'success',
            });
          },
          error: (error) => {
            this.notifyServ.showMessage({
              message: error.message,
              status: 'failed',
            });
          },
        });
      this.destroyRef.onDestroy(() => subscription.unsubscribe());
      this.refreshRoute();
    }
  }
  refreshRoute() {
    this.router.navigate([this.router.url]);
  }
  onCancel(localAppID: number) {
    this.current_app_id = localAppID;
    this.isDialogVisible.set(true);
  }
}
