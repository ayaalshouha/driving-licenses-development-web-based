import { Component, DestroyRef, inject, PLATFORM_ID } from '@angular/core';
import { DetainedLicense } from '../../../models/detained-license.model';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { DetainedLicenseService } from '../../../services/detained-license.service';
import { tap } from 'rxjs';
import { CurrencyPipe, DatePipe, isPlatformBrowser } from '@angular/common';
import { LicenseService } from '../../../services/license.service';
import { NotificationService } from '../../../services/notification.service';

@Component({
  selector: 'app-detained-licenses',
  standalone: true,
  imports: [ReactiveFormsModule, DatePipe, CurrencyPipe],
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

  constructor(
    private detainedlicenseServ: DetainedLicenseService,
    private licenseServ: LicenseService,
    private notifyServ: NotificationService
  ) {}

  ngOnInit(): void {
    if (isPlatformBrowser(PLATFORM_ID)) {
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

    this.filter.valueChanges
      .pipe(tap((response) => this.applyFilter(response)))
      .subscribe();
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

  onRelease(licenseID: number) {
    const subscription = this.licenseServ
      .release(licenseID, this.current_user_id!)

      .subscribe((response) => {
        if (response) {
          this.notifyServ.showMessage({
            message: ` licese ${licenseID} released successfully`,
            status: 'success',
          });
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
