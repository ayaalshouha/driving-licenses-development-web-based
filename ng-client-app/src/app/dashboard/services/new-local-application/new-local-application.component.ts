import { Component, DestroyRef, inject, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CountryService } from '../../../services/country.service';
import { LicenseClass } from '../../../models/license-class.model';
import { LicenseClassService } from '../../../services/license-class.service';
import { forkJoin } from 'rxjs';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-new-local-application',
  standalone: true,
  imports: [ReactiveFormsModule, DatePipe],
  templateUrl: './new-local-application.component.html',
  styleUrl: './new-local-application.component.css',
})
export class NewLocalApplicationComponent implements OnInit {
  countries: string[] = [];
  license_classes: LicenseClass[] = [];
  current_date: Date = new Date();
  private destroyRef = inject(DestroyRef);
  register_form = new FormGroup({
    firstname: new FormControl('', {
      validators: [Validators.required],
    }),
    secondname: new FormControl('', {
      validators: [Validators.required],
    }),
    thirdname: new FormControl('', {
      validators: [Validators.required],
    }),
    lastname: new FormControl('', {
      validators: [Validators.required],
    }),
    // add unique National No validator from server
    nationalno: new FormControl('', {
      validators: [Validators.required, Validators.pattern('^[0-9]{10}$')],
    }),
    email: new FormControl('', {
      validators: [Validators.required, Validators.email],
    }),
    phonenumber: new FormControl('', {
      validators: [Validators.required, Validators.minLength(10)],
    }),
    gender: new FormControl<'Male' | 'Female'>('Male', {
      validators: [Validators.required],
    }),
    birthdate: new FormControl('', {
      validators: [Validators.required],
    }),
    country: new FormControl('', {
      validators: [Validators.required],
    }),
    address: new FormControl('', {
      validators: [Validators.required],
    }),
    img: new FormControl(''),
    licenseclass: new FormControl('', {
      validators: [Validators.required],
    }),
  });

  constructor(
    private countryService: CountryService,
    private licenseClassService: LicenseClassService
  ) {}

  ngOnInit(): void {
    // (forkJoin) perform two independent observable and get their results together in one subscription
    const subscription = forkJoin({
      countries: this.countryService.AllCountries(),
      classes: this.licenseClassService.getAllClasses(),
    }).subscribe(({ countries, classes }) => {
      this.countries = countries;
      this.license_classes = classes;
    });

    this.destroyRef.onDestroy(() => subscription.unsubscribe());
  }

  get invalidEmail(){
    return (
      this.register_form.controls.email.touched &&
      this.register_form.controls.email.dirty &&
      this.register_form.controls.email.invalid
    );
  }
  get invalidNationalNo() {
    return (
      this.register_form.controls.nationalno.touched &&
      this.register_form.controls.nationalno.dirty &&
      this.register_form.controls.nationalno.invalid
    );
  }

  get invalidPhoneNumber() {
    return (
      this.register_form.controls.phonenumber.touched &&
      this.register_form.controls.phonenumber.dirty &&
      this.register_form.controls.phonenumber.invalid
    );
  }

  onSubmit() {
    if (this.register_form.invalid) {
      console.log('invalid form');
      return;
    }
  }
}
