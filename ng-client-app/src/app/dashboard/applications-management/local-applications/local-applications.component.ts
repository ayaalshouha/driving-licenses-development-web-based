import { Component, DestroyRef, inject, OnInit } from '@angular/core';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { tap } from 'rxjs';
import { LocalApplicationView } from '../../../models/local-application.model';
import { LocalApplicationService } from '../../../services/local-application.service';

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
  dataDisplayed: LocalApplicationView[] = [];
  private destroyRef = inject(DestroyRef);
  filter = new FormControl('', { nonNullable: true });

  constructor(private localAppService: LocalApplicationService) {}

  ngOnInit(): void {
    const subscription = this.localAppService
      .getAll()
      .pipe(
        tap((response) => {
          this.applications = response;
          this.updateDisplayedData(0);
        })
      )
      .subscribe();

    this.destroyRef.onDestroy(() => subscription.unsubscribe());
  }

  updateDisplayedData(startIndex: number = 0) {
    const endIndex = startIndex + this.pageSize;
    this.dataDisplayed = this.applications.slice(startIndex, endIndex);
  }
  onNext() {
    if (this.currentPage * this.pageSize < this.applications.length) {
      this.currentPage++;
      this.updateDisplayedData((this.currentPage - 1) * this.pageSize);
    }
  }
  onPrevious() {
    this.currentPage--;
    this.updateDisplayedData((this.currentPage - 1) * this.pageSize);
  }
}
