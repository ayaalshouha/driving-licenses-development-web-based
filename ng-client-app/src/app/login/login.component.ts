import { Component, DestroyRef, inject, signal } from '@angular/core';
import {
  AbstractControl,
  AsyncValidatorFn,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { LoginService } from '../services/login.service';
import { UserService } from '../services/user.service';
import {
  catchError,
  concatMap,
  debounceTime,
  map,
  of,
  switchMap,
  tap,
} from 'rxjs';
import { Router } from '@angular/router';
import { CurrentUserService } from '../services/current-user.service';

//when register NOT login
export function usernameAsyncValidator(
  loginService: LoginService
): AsyncValidatorFn {
  return (control: AbstractControl) => {
    if (!control.value) {
      return of(null);
    }
    return loginService.isExist(control.value).pipe(
      debounceTime(300),
      map((isTaken) => (isTaken ? { usernameTaken: true } : null)),
      catchError(() => of(null))
    );
  };
}

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
  private destroyRef = inject(DestroyRef);
  private userService = inject(UserService);
  private router = inject(Router);
  private loginService = inject(LoginService);
  login_form = new FormGroup({
    username: new FormControl('', {
      validators: [Validators.required],
      asyncValidators: [usernameAsyncValidator(this.loginService)],
    }),
    password: new FormControl('', {
      validators: [Validators.required, Validators.minLength(6)],
    }),
  });

  constructor(private currentUserService: CurrentUserService) {}

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
    if (this.invalidForm) {
      return;
    }

    this.enteredUsername.set(this.login_form.controls.username.value!);
    this.enteredPassword.set(this.login_form.controls.password.value!);

    const subscription = this.loginService
      .isCorrect(this.enteredUsername(), this.enteredPassword())
      .pipe(
        tap((isExistValue) => this.isExist.set(isExistValue)),
        switchMap((isExistValue) => {
          if (!isExistValue) {
            throw new Error('User does not exist.');
          }
          return this.loginService.isActive(
            this.enteredUsername(),
            this.enteredPassword()
          );
        }),
        tap((isActiveValue) => this.isActive.set(isActiveValue)),
        switchMap((isActiveValue) => {
          if (!isActiveValue) {
            throw new Error('User is not active.');
          }
          return this.userService.getUser(this.enteredUsername());
        }),
        // Changed to concatMap to wait for saveLogin to complete
        concatMap((fullUser) => {
          this.currentUserService.setCurrentUser(fullUser);
          // saveLogin returns an observable
          return this.loginService.saveLogin(
            this.currentUserService.getCurrentUser()!.id
          );
        })
      )
      .subscribe({
        next: () => {
          //which will only be executed after the entire observable chain completes successfully.
        },
        complete: () => {
          //will work as expected, but only if the entire observable chain completes successfully (i.e., no errors were thrown
          this.loginService.setLoginStatus(true);
          this.router.navigate(['/dashboard']);
        },
        error: (err) => {
          console.error('Error during login process:', err.message || err);
        },
      });

    this.destroyRef.onDestroy(() => subscription.unsubscribe());
  }
}
