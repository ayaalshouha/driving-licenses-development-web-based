import { Component, DestroyRef, inject, OnInit } from '@angular/core';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { tap } from 'rxjs';
import { LocalApplicationView } from '../../../models/local-application.model';
import { LocalApplicationService } from '../../../services/local-application.service';
import { LowerCasePipe } from '@angular/common';

@Component({
  selector: 'app-local-applications',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './local-applications.component.html',
  styleUrl: './local-applications.component.css',
})
export class LocalApplicationsComponent implements OnInit {
  currentPage = 1;
  pageSize = 5;
  applications: LocalApplicationView[] = [];
  filteredApplications: LocalApplicationView[] = [];
  displayedData: LocalApplicationView[] = [];
  private destroyRef = inject(DestroyRef);
  filter = new FormControl('', { nonNullable: true });

  constructor(private localAppService: LocalApplicationService) {}

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
          this.updateDisplayedData();
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
    console.log('filtered applications', this.filteredApplications);
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
}
