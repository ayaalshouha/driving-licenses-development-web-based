import {
  Component,
  DestroyRef,
  EventEmitter,
  inject,
  signal,
} from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { LoginService } from '../services/login.service';
import { User } from '../models/user.model';
import { UserService } from '../services/user.service';
import { firstValueFrom, from, switchMap, tap } from 'rxjs';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  loggedIn = signal<boolean>(false);
  isExist = signal<Boolean | undefined>(undefined);
  isActive = signal<Boolean | undefined>(undefined);
  isLoginSaved = signal<Boolean | undefined>(undefined);
  enteredUsername = signal<string>('');
  enteredPassword = signal<string>('');
  onclose = new EventEmitter<User>();
  private destroyRef = inject(DestroyRef);
  private userService = inject(UserService);
  private currentUser: User | undefined = undefined;

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

  onSubmit() {
    if (this.invalidForm) {
      return;
    }

    this.enteredUsername.set(this.login_form.controls.username.value!);
    this.enteredPassword.set(this.login_form.controls.password.value!);

    this.loginService
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

        switchMap((fullUser) => {
          this.currentUser = fullUser;
          this.onclose.emit(this.currentUser);
          return this.loginService.saveLogin(this.currentUser!.id); // saveLogin returns an observable
        })
      )
      .subscribe({
        error: (err) => {
          console.error('Error during login process:', err.message || err);
        },
      });
  }
}
