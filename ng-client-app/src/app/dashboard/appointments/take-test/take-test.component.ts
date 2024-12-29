import { Component, OnInit } from '@angular/core';
import { AppointmentService } from '../../../services/appointment.service';
import { TestService } from '../../../services/test.service';
import { Test } from '../../../models/test.model';
import { NumberSymbol } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-take-test',
  standalone: true,
  imports: [],
  templateUrl: './take-test.component.html',
  styleUrl: './take-test.component.css',
})
export class TakeTestComponent implements OnInit {
  id: number | null = null;
  test: Test | null = null;
  constructor(
    private route: ActivatedRoute,
    private appointmetnService: AppointmentService,
    private testService: TestService
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => (this.id = +params['id']));
  }
}
