import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { MakeAppointmentComponent } from '../make-appointment/make-appointment.component';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
@Component({
  selector: 'app-add-edit-appointment',
  standalone: true,
  imports: [MakeAppointmentComponent],
  templateUrl: './add-edit-appointment.component.html',
  styleUrl: './add-edit-appointment.component.css',
})
export class AddEditAppointmentComponent implements OnInit {
  mode: string | null = null;
  id: number | null = null;

  constructor(
    private cdr: ChangeDetectorRef,
    private route: ActivatedRoute,
    private router: Router,
    private location: Location
  ) {}
  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.mode = params['mode'];
      this.id = +params['id'];
    });

    console.log('from OnInit ' + this.id);
    this.cdr.detectChanges();
  }

  onClose(confirmed: boolean) {
    if (confirmed) {
      this.location.back();
    } else return;
  }
}
