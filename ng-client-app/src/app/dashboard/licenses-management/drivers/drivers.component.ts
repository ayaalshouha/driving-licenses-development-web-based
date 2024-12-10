import { Component, DestroyRef, inject, Inject, OnInit } from '@angular/core';
import { Driver } from '../../../models/driver.model';
import { DriverService } from '../../../services/driver.service';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { tap } from 'rxjs';
@Component({
  selector: 'app-drivers',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './drivers.component.html',
  styleUrl: './drivers.component.css',
})
export class DriversComponent implements OnInit {
  currentPage = 1;
  pageSize = 5;
  drivers: Driver[] = [];
  dataDisplayed: Driver[] = [];
  private destroyRef = inject(DestroyRef);
  filter = new FormControl('', { nonNullable: true });

  constructor(private driverService: DriverService) {}

  ngOnInit(): void {
    const subscription = this.driverService
      .getAll()
      .pipe(
        tap((response) => {
          this.drivers = response;
          this.updateDisplayedData(0);
        })
      )
      .subscribe();

    this.destroyRef.onDestroy(() => subscription.unsubscribe());
  }

  updateDisplayedData(startIndex: number = 0) {
    const endIndex = startIndex + this.pageSize;
    this.dataDisplayed = this.drivers.slice(startIndex, endIndex);
  }
  onNext() {
    if (this.currentPage * this.pageSize < this.drivers.length) {
      this.currentPage++;
      this.updateDisplayedData((this.currentPage - 1) * this.pageSize);
    }
  }
  onPrevious() {
    this.currentPage--;
    this.updateDisplayedData((this.currentPage - 1) * this.pageSize);
  }
}
