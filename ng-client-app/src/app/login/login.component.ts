import {
  Component,
  DestroyRef,
  EventEmitter,
  inject,
  output,
  signal,
} from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { LoginService } from '../services/login.service';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user.model';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  isExist = signal<Boolean | undefined>(undefined);
  isActive = signal<Boolean | undefined>(undefined);
  isLoginSaved = signal<Boolean | undefined>(undefined);
  enteredUsername = signal<string>('');
  enteredPassword = signal<string>('');
   onclose = new EventEmitter<User>();
  private destroyRef = inject(DestroyRef);

  login_form = new FormGroup({
    username: new FormControl('', {
      validators: [Validators.required],
    }),
    password: new FormControl('', {
      validators: [Validators.required, Validators.minLength(6)],
    }),
  });

  constructor(private loginService: LoginService) {}

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

  checkActivity(): void {
    if (this.isExist() === true) {
      const subscription2 = this.loginService
        .isActive(this.enteredUsername(), this.enteredPassword())
        .subscribe({
          next: (value) => {
            this.isActive.set(value);
          },
          error: (err) => console.log('error in active request ' + err),
        });
      this.destroyRef.onDestroy(() => subscription2.unsubscribe());
    }
  }

  onSubmit() {
    if (this.invalidForm) {
      return;
    }
    this.enteredUsername.set(this.login_form.controls.username.value!);
    this.enteredPassword.set(this.login_form.controls.password.value!);

    const subscription1 = this.loginService
      .isCorrect(this.enteredUsername(), this.enteredPassword())
      .subscribe({
        next: (value) => {
          this.isExist.set(value);
        },
      });
    this.destroyRef.onDestroy(() => subscription1.unsubscribe());

    this.checkActivity();

    if (this.isExist() === true && this.isActive() === true) {
      //save login and current user
      
    }
  }
}
