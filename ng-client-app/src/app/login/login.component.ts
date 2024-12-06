import {
  Component,
  DestroyRef,
  Inject,
  inject,
  OnInit,
  PLATFORM_ID,
  signal,
} from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { LoginService } from '../services/login.service';
import { UserService } from '../services/user.service';
import { concatMap, debounceTime, switchMap, tap } from 'rxjs';
import { Router } from '@angular/router';
import { CurrentUserService } from '../services/current-user.service';
import { isPlatformBrowser } from '@angular/common';
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent implements OnInit {
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
    }),
    password: new FormControl('', {
      validators: [Validators.required, Validators.minLength(6)],
    }),
  });

  constructor(
    private currentUserService: CurrentUserService,
    @Inject(PLATFORM_ID) private platformId: Object
  ) {}
  ngOnInit(): void {
    if (isPlatformBrowser(this.platformId)) {
      //get latest login credintioal from local storage
      const savedItem = window.localStorage.getItem('saved-login');
      if (savedItem) {
        const loadedData = JSON.parse(savedItem);
        const savedUsername = loadedData.username;
        const savedPassword = loadedData.password;

        this.login_form.patchValue({
          username: savedUsername,
          password: savedPassword,
        });
      }
      // save login creditional to local storage
      const subscription = this.login_form.valueChanges
        .pipe(debounceTime(500))
        .subscribe({
          next: (val) => {
            window.localStorage.setItem(
              'saved-login',
              JSON.stringify({
                username: val.username,
                password: val.password,
              })
            );
          },
        });
      this.destroyRef.onDestroy(() => subscription.unsubscribe());
    }
    console.log(this.currentUserService.getCurrentUser());
  }

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
          return this.userService.readUser(this.enteredUsername());
        }),
        // Changed to concatMap to wait for saveLogin to complete
        concatMap((fullUser) => {
          //save current user in local storage
          window.localStorage.setItem('current-user', JSON.stringify(fullUser));
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
          this.router.navigate(['/dashboard']);
        },
        error: (err) => {
          console.error('Error during login process:', err.message || err);
        },
      });

    this.destroyRef.onDestroy(() => subscription.unsubscribe());
  }
}
