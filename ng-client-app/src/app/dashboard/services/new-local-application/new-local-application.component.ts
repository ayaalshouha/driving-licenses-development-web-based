import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-new-local-application',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './new-local-application.component.html',
  styleUrl: './new-local-application.component.css',
})
export class NewLocalApplicationComponent {
  register_form = new FormGroup({
    firstname: new FormControl(),
    secondname: new FormControl(),
    thirdname: new FormControl(),
    lastname: new FormControl(),
    nationalno: new FormControl(),
    email: new FormControl(),
    phonenumber: new FormControl(),
    gender: new FormControl<'Male' | 'Male'>('Male', {
      validators: [Validators.required],
    }),
    birthdate: new FormControl(),
    country: new FormControl(),
    address: new FormControl(),
    img: new FormControl(),
    licenseclass: new FormControl(),
  });

  onSubmit() {}
}
