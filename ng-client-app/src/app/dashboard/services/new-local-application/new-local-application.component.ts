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

@Component({
  selector: 'app-new-local-application',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './new-local-application.component.html',
  styleUrl: './new-local-application.component.css',
})
export class NewLocalApplicationComponent implements OnInit {
  countries: string[] = [];
  license_classes: LicenseClass[] = [];
  private destroyRef = inject(DestroyRef);
  register_form = new FormGroup({
    firstname: new FormControl(),
    secondname: new FormControl(),
    thirdname: new FormControl(),
    lastname: new FormControl(),
    nationalno: new FormControl(),
    email: new FormControl(),
    phonenumber: new FormControl(),
    gender: new FormControl<'Male' | 'Female'>('Male', {
      validators: [Validators.required],
    }),
    birthdate: new FormControl(),
    country: new FormControl(),
    address: new FormControl(),
    img: new FormControl(),
    licenseclass: new FormControl(),
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
  onSubmit() {}
}
