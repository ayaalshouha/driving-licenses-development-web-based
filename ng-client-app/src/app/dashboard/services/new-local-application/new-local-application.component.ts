import { Component, DestroyRef, inject, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CountryService } from '../../../services/country.service';
import { countReset } from 'console';

@Component({
  selector: 'app-new-local-application',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './new-local-application.component.html',
  styleUrl: './new-local-application.component.css',
})
export class NewLocalApplicationComponent implements OnInit {
  countries: string[] = [];
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

  constructor(private countryService: CountryService) {}

  ngOnInit(): void {
    const subscription = this.countryService
      .AllCountries()
      .subscribe((data) => {
        this.countries = data;
        console.log(this.countries);
      });

    this.destroyRef.onDestroy(() => subscription.unsubscribe());
  }
  onSubmit() {}
}
