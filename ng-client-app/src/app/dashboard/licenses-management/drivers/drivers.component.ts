import { Component, DestroyRef, inject, Inject, OnInit } from '@angular/core';
import { Driver_View } from '../../../models/driver.model';
import { DriverService } from '../../../services/driver.service';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { tap } from 'rxjs';
import { RouterLink } from '@angular/router';
@Component({
  selector: 'app-drivers',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './drivers.component.html',
  styleUrl: './drivers.component.css',
})
export class DriversComponent implements OnInit {
  currentPage = 1;
  pageSize = 5;
  drivers: Driver_View[] = [];
  filteredDrivers: Driver_View[] = [];
  displayedData: Driver_View[] = [];
  private destroyRef = inject(DestroyRef);
  filter = new FormControl('', { nonNullable: true });

  constructor(private driverService: DriverService) {}

  ngOnInit(): void {
    const subscription = this.driverService
      .getAll()
      .pipe(
        tap((response) => {
          this.drivers = response;
          this.filteredDrivers = response;
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
    this.filteredDrivers = this.drivers.filter((item) =>
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
    this.displayedData = this.filteredDrivers.slice(startIndex, endIndex);
  }
  onNext() {
    if (this.currentPage * this.pageSize < this.drivers.length) {
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
