import { Component, OnDestroy, OnInit, signal } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Subscription, tap } from 'rxjs';
import { User } from '../../models/user.model';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { NotificationService } from '../../services/notification.service';
import { ConfirmationDialogComponent } from '../../shared/confirmation-dialog/confirmation-dialog.component';
import { NotificationComponent } from '../../shared/notification/notification.component';

@Component({
  selector: 'app-accounts',
  standalone: true,
  imports: [
    // ConfirmationDialogComponent,
    NotificationComponent,
    ReactiveFormsModule,
  ],
  templateUrl: './accounts.component.html',
  styleUrl: './accounts.component.css',
})
export class AccountsComponent implements OnInit, OnDestroy {
  subcriptions: Subscription[] = [];
  current_app_id: number | null = null;
  currentPage = 1;
  pageSize = 5;
  users: User[] = [];
  filteredUsers: User[] = [];
  displayedData: User[] = [];
  filter = new FormControl('', { nonNullable: true });
  isDialogVisible = signal<boolean>(false);
  constructor(
    private userService: UserService,
    private notifyServ: NotificationService
  ) {}

  ngOnInit(): void {
    this.loadData();
    this.filter.valueChanges
      .pipe(
        tap((value) => {
          this.applyFilter(value);
        })
      )
      .subscribe();
  }

  loadData(): void {
    const subscription = this.userService.all().subscribe((data) => {
      this.users = data;
      this.filteredUsers = data;
      this.updateDisplayedData();
    });

    this.subcriptions.push(subscription);
  }

  applyFilter(value: string) {
    const lowerCaseFilter = value.toLowerCase();
    this.filteredUsers = this.users.filter((item) =>
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
    this.displayedData = this.filteredUsers.slice(startIndex, endIndex);
  }
  onNext() {
    if (this.currentPage * this.pageSize < this.filteredUsers.length) {
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

  // onDialogResult(isConfirmed: boolean) {
  //   this.isDialogVisible.set(false);
  //   if (isConfirmed && this.current_app_id !== null) {
  //     const subscription = this.localAppService
  //       .cancel(this.current_app_id)
  //       .pipe(catchError((error) => throwError(() => new Error(error))))
  //       .subscribe({
  //         next: () => {
  //           this.notifyServ.showMessage({
  //             message: 'Application cancelled successfully',
  //             status: 'success',
  //           });
  //           this.loadData();
  //         },
  //         error: (error) => {
  //           this.notifyServ.showMessage({
  //             message: error.message,
  //             status: 'failed',
  //           });
  //         },
  //       });
  //     this.subcriptions.push(subscription);
  //   }
  // }

  // onCancel(localAppID: number) {
  //   this.current_app_id = localAppID;
  //   this.isDialogVisible.set(true);
  // }

  ngOnDestroy(): void {
    this.subcriptions.forEach((sub) => sub.unsubscribe());
  }
}
