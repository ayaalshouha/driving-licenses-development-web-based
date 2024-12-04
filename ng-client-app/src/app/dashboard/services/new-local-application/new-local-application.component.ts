import {
  Component,
  DestroyRef,
  effect,
  inject,
  OnInit,
  signal,
} from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CountryService } from '../../../services/country.service';
import { LicenseClass } from '../../../models/license-class.model';
import { LicenseClassService } from '../../../services/license-class.service';
import { concatMap, forkJoin, switchMap, tap, throwError } from 'rxjs';
import { DatePipe } from '@angular/common';
import { CanDeactivateFn } from '@angular/router';
import { isPlatformBrowser } from '@angular/common';
import { isExist } from '../../custom-validator';
import { PersonService } from '../../../services/person.service';
import { Person } from '../../../models/person.model';
import { CurrentUserService } from '../../../services/current-user.service';
import { Application } from '../../../models/application.model';
import { ApplicationService } from '../../../services/application.service';
import { LocalApplicationService } from '../../../services/local-application.service';
import { matSnackBar } from '@angular/material/snack-bar';
import {
  ApplicationType,
  ApplicationTypes,
} from '../../../models/application-type.model';
import { LocalApplication } from '../../../models/local-application.model';

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
  new_app_saved = signal<boolean>(false);
  private application_types: ApplicationType[] = ApplicationTypes;
  private destroyRef = inject(DestroyRef);
  private personService = inject(PersonService);

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
      asyncValidators: [isExist(this.personService)],
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
    birthdate: new FormControl(this.current_date, {
      validators: [Validators.required],
    }),
    country: new FormControl('', {
      validators: [Validators.required],
    }),
    address: new FormControl('', {
      validators: [Validators.required],
    }),
    img: new FormControl(''),
    licenseclass: new FormControl(0, {
      validators: [Validators.required],
    }),
  });

  constructor(
    private countryService: CountryService,
    private licenseClassService: LicenseClassService,
    private currentUserSerice: CurrentUserService,
    private applicationService: ApplicationService,
    private localAppService: LocalApplicationService
  ) {
    effect();
  }

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

  get invalidForm() {
    return this.register_form.invalid;
  }
  get invalidEmail() {
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
  get notUniqueNationalNo() {
    return this.register_form.controls.nationalno?.hasError('notUnique');
  }
  get invalidPhoneNumber() {
    return (
      this.register_form.controls.phonenumber.touched &&
      this.register_form.controls.phonenumber.dirty &&
      this.register_form.controls.phonenumber.invalid
    );
  }

  onSubmit() {
    if (this.register_form.valid) {
      let new_person: Person = {
        id: 0,
        firstName: this.register_form.controls.firstname.value!,
        secondName: this.register_form.controls.secondname.value!,
        thirdName: this.register_form.controls.thirdname.value!,
        lastName: this.register_form.controls.lastname.value!,
        address: this.register_form.controls.address.value!,
        birthDate: this.register_form.controls.birthdate.value!,
        email: this.register_form.controls.email.value!,
        gender: this.register_form.controls.gender.value!,
        nationality: this.register_form.controls.country.value!,
        createdByUserID: this.currentUserSerice.getCurrentUser()!.id,
        creationDate: this.current_date,
        updatedByUserID: 0,
        updatedDate: this.current_date,
        personalPicture: this.register_form.controls.img.value!,
        nationalNumber: this.register_form.controls.nationalno.value!,
        phoneNumber: this.register_form.controls.phonenumber.value!,
      };
      let new_app: Application = {
        id: 0,
        personID: 0,
        status: 1,
        type: 1,
        date: this.current_date,
        paidFees: this.application_types.at(1)!.typeFees,
        lastStatusDate: this.current_date,
        createdByUserID: this.currentUserSerice.getCurrentUser()!.id,
      };
      let local_app: LocalApplication = {
        id: 0,
        applicationID: 0,
        licenseClassID: +this.register_form.controls.licenseclass.value!,
      };
      const subscription = this.personService
        .create(new_person)
        .pipe(
          switchMap((response) => {
            if (response.id === 0) {
              return throwError(() => new Error('Invalid person info'));
            } else {
              new_app.personID = response.id;
              return this.applicationService.create(new_app);
            }
          }),
          concatMap((response) => {
            if (response.id === 0) {
              return throwError(() => new Error('Invalid application info'));
            } else {
              local_app.applicationID = response.id;
              return this.localAppService.create(local_app);
            }
          })
        )
        .subscribe({
          complete: () => {
            this.new_app_saved.set(true);
          },
          error: (err) => {
            console.error(err);
          },
        });
    }
  }
}

// The error appears in the canDeactivate function.
// If canDeactivate directly references window, it will fail during SSR.
export const canDeactivate: CanDeactivateFn<NewLocalApplicationComponent> = (
  component,
  platformId: Object
) => {
  if (isPlatformBrowser(platformId)) {
  }
  return window.confirm(
    'Are you sure you want to leave? Unsaved changes will be lost.'
  );
};
