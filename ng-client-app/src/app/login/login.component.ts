import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  login_form = new FormGroup({
    username: new FormControl('', {
      validators: [Validators.required],
    }),
    password: new FormControl('', {
      validators: [Validators.required, Validators.minLength(6)],
    }),
  });

  get invalidUsername() {
    return (
      this.login_form.controls.username.touched &&
      this.login_form.controls.username.dirty &&
      this.login_form.controls.username.invalid
    );
  }

  get invalidPassword() {
    return (
      this.login_form.controls.password.touched &&
      this.login_form.controls.password.dirty &&
      this.login_form.controls.password.invalid
    );
  }

  get invalidForm() {
    return this.login_form.invalid;
  }
  onSubmit() {
    if(this.invalidForm){
      return;
    }
    console.log(this.login_form);
  }
}
