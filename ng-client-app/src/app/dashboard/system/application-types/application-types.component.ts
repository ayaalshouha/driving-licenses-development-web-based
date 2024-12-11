import { Component, DestroyRef, inject, OnInit } from '@angular/core';
import { ApplicationType } from '../../../models/application-type.model';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { ApplicationTypesService } from '../../../services/application-type.service';
import { tap } from 'rxjs';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-application-types',
  standalone: true,
  imports: [ReactiveFormsModule, CurrencyPipe],
  templateUrl: './application-types.component.html',
  styleUrl: './application-types.component.css',
})
export class ApplicationTypesComponent implements OnInit {
  currentPage = 1;
  pageSize = 7;
  types: ApplicationType[] = [];
  dataDisplayed: ApplicationType[] = [];
  private destroyRef = inject(DestroyRef);
  filter = new FormControl('', { nonNullable: true });

  constructor(private applicationtypesService: ApplicationTypesService) {}

  ngOnInit(): void {
    const subscription = this.applicationtypesService
      .all()
      .pipe(
        tap((response) => {
          this.types = response;
          this.updateDisplayedData(0);
        })
      )
      .subscribe();

    this.destroyRef.onDestroy(() => subscription.unsubscribe());
  }

  updateDisplayedData(startIndex: number = 0) {
    const endIndex = startIndex + this.pageSize;
    this.dataDisplayed = this.types.slice(startIndex, endIndex);
  }
  onNext() {
    if (this.currentPage * this.pageSize < this.types.length) {
      this.currentPage++;
      this.updateDisplayedData((this.currentPage - 1) * this.pageSize);
    }
  }
  onPrevious() {
    this.currentPage--;
    this.updateDisplayedData((this.currentPage - 1) * this.pageSize);
  }
}
