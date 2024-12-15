import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { TestType } from '../../../models/test-type.model';
import { TestTypesService } from '../../../services/test-type.service';
import { tap } from 'rxjs';

@Component({
  selector: 'app-make-appointment',
  standalone: true,
  imports: [ReactiveFormsModule, DatePipe],
  templateUrl: './make-appointment.component.html',
  styleUrl: './make-appointment.component.css',
})
export class MakeAppointmentComponent {
  testTypes: TestType[] = [];
  constructor(private testTypeService: TestTypesService) {
    const subscription = this.testTypeService
      .all()
      .pipe(
        tap((response) => {
          this.testTypes = response;
        })
      )
      .subscribe();
  }
  filter = new FormControl('', { nonNullable: true });
  current_date = new Date();
  application_info = new FormGroup({
    applicantName: new FormControl('', {}),
    applicationType: new FormControl('', {}),
    className: new FormControl('', {}),
    status: new FormControl('', {}),
    fee: new FormControl('', {}),
    date: new FormControl('', {}),
    passedTest: new FormControl('', {}),
    testType: new FormControl('', {}),
  });
}
