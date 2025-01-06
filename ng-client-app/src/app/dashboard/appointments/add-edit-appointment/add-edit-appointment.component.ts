import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { MakeAppointmentComponent } from '../make-appointment/make-appointment.component';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { DialogWrapperComponent } from '../../../shared/dialog-wrapper/dialog-wrapper.component';
@Component({
  selector: 'app-add-edit-appointment',
  standalone: true,
  imports: [MakeAppointmentComponent, DialogWrapperComponent],
  templateUrl: './add-edit-appointment.component.html',
  styleUrl: './add-edit-appointment.component.css',
})
export class AddEditAppointmentComponent implements OnInit {
  mode: string | null = null;
  application_id: number | null = null;
  person_id: number | null = null;

  constructor(
    private cdr: ChangeDetectorRef,
    private route: ActivatedRoute,
    private router: Router,
    private location: Location
  ) {}
  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.mode = params['mode'];
      this.application_id = +params['application_id'];
    });
    this.cdr.detectChanges();
  }

  onClose(confirmed: boolean) {
    if (confirmed) {
      this.location.back();
    } else return;
  }
}
