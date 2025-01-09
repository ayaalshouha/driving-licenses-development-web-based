import {
  Component,
  DestroyRef,
  Inject,
  inject,
  PLATFORM_ID,
  signal,
} from '@angular/core';
import { DetainedLicense } from '../../../models/detained-license.model';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { DetainedLicenseService } from '../../../services/detained-license.service';
import { tap } from 'rxjs';
import { CurrencyPipe, DatePipe, isPlatformBrowser } from '@angular/common';
import { LicenseService } from '../../../services/license.service';
import { NotificationService } from '../../../services/notification.service';
import { ConfirmationDialogComponent } from '../../../shared/confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-detained-licenses',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    DatePipe,
    CurrencyPipe,
    ConfirmationDialogComponent,
  ],
  templateUrl: './detained-licenses.component.html',
  styleUrl: './detained-licenses.component.css',
})
export class DetainedLicensesComponent {
  current_user_id: number | null = null;
  currentPage = 1;
  pageSize = 6;
  list: DetainedLicense[] = [];
  filteredList: DetainedLicense[] = [];
  displayedData: DetainedLicense[] = [];
  private destroyRef = inject(DestroyRef);
  filter = new FormControl('', { nonNullable: true });
  isDialogVisible = signal<boolean>(false);
  licenseID: number | undefined = undefined;
  constructor(
    @Inject(PLATFORM_ID) private platformId: Object,
    private detainedlicenseServ: DetainedLicenseService,
    private licenseServ: LicenseService,
    private notifyServ: NotificationService
  ) {}

  ngOnInit(): void {
    if (isPlatformBrowser(this.platformId)) {
      const current_user = window.localStorage.getItem('current-user');
      if (current_user) {
        try {
          const user = JSON.parse(current_user);
          this.current_user_id = user.id;
        } catch (error) {
          console.error('Error parsing user data from local storage:', error);
        }
      }
    }
    this.loadData();
    this.filter.valueChanges
      .pipe(tap((response) => this.applyFilter(response)))
      .subscribe();
  }

  loadData() {
    const subscription = this.detainedlicenseServ
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

  onDialogResult(confirmed: boolean) {
    this.isDialogVisible.set(false);
    if (confirmed) {
      const subscription = this.licenseServ
        .release(this.licenseID!, this.current_user_id!)

        .subscribe((response) => {
          if (response) {
            this.notifyServ.showMessage({
              message: ` licese ${this.licenseID} released successfully`,
              status: 'success',
            });
            this.loadData();
          } else {
            this.notifyServ.showMessage({
              message: `Something went wrong, please try again later!`,
              status: 'failed',
            });
          }
        });

      this.destroyRef.onDestroy(() => subscription.unsubscribe());
    }
  }
  onRelease(licenseID: number) {
    this.licenseID = licenseID;
    this.isDialogVisible.set(true);
  }
}
