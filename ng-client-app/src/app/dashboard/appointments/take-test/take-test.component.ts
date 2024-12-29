import { Component, OnDestroy, OnInit } from '@angular/core';
import { AppointmentService } from '../../../services/appointment.service';
import { TestService } from '../../../services/test.service';
import { Test } from '../../../models/test.model';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Subject } from 'rxjs';
@Component({
  selector: 'app-take-test',
  standalone: true,
  imports: [],
  templateUrl: './take-test.component.html',
  styleUrl: './take-test.component.css',
})
export class TakeTestComponent implements OnInit, OnDestroy {
  id: number | null = null;
  test: Test | null = null;
  private destroy$ = new Subject<void>();
  constructor(
    private route: ActivatedRoute,
    private appointmetnService: AppointmentService,
    private testService: TestService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => (this.id = +params['id']));
  }

  onSubmit() {
    console.log('test submitted');
  }

  onCancel() {
    this.location.back();
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
