import {
  Component,
  DestroyRef,
  EventEmitter,
  inject,
  Input,
  OnChanges,
  OnInit,
  Output,
  signal,
  SimpleChanges,
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
import {
  catchError,
  concatMap,
  forkJoin,
  switchMap,
  tap,
  throwError,
} from 'rxjs';
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
import { PLATFORM_ID } from '@angular/core';

import {
  ApplicationType,
  ApplicationTypes,
} from '../../../models/application-type.model';
import { LocalApplication } from '../../../models/local-application.model';
import {
  NotificationBox,
  NotificationService,
} from '../../../services/notification.service';
import { ConfirmationDialogComponent } from '../../../shared/confirmation-dialog/confirmation-dialog.component';
export enum enMode {
  add = 'Add appointment',
  edit = 'Edit appointment',
}
@Component({
  selector: 'app-new-local-application',
  standalone: true,
  imports: [ReactiveFormsModule, DatePipe, ConfirmationDialogComponent],
  templateUrl: './new-local-application.component.html',
  styleUrl: './new-local-application.component.css',
})
export class NewLocalApplicationComponent implements OnInit, OnChanges {
  @Output() closed = new EventEmitter<boolean>();
  @Input() applicationID: number | null = null;
  application_mode = this.applicationID == null ? enMode.add : enMode.edit;
  enMode = enMode;
  countries: string[] = [];
  license_classes: LicenseClass[] = [];
  current_date: Date = new Date();
  private application_types: ApplicationType[] = ApplicationTypes;
  private destroyRef = inject(DestroyRef);
  private personService = inject(PersonService);
  isDialogVisible = signal<boolean>(false);
  isConfirmed = signal<boolean>(false);
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
    licenseclass: new FormControl(1, {
      validators: [Validators.required],
    }),
  });

  constructor(
    private countryService: CountryService,
    private licenseClassService: LicenseClassService,
    private currentUserSerice: CurrentUserService,
    private applicationService: ApplicationService,
    private localAppService: LocalApplicationService,
    private notificationSerice: NotificationService
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
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['applicationID'] && changes['applicationID'].currentValue) {
      this.initializeMode();
      this.handleEditMode();
    }
  }
  private initializeMode(): void {
    this.application_mode =
      this.applicationID == null ? enMode.add : enMode.edit;
  }
  private handleEditMode(): void {
    if (this.application_mode === enMode.edit && this.applicationID) {
      this.retrieveApplication(this.applicationID);
    }
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

  onDialogResult(result: boolean) {
    this.isDialogVisible.set(false);
    this.isConfirmed.set(result);
  }

  retrieveApplication(application_id: number) {
    // retrieving current application
    if (application_id && this.application_mode == enMode.edit) {
      const subscription = this.localAppService
        .read(application_id)
        .pipe(
          catchError((error) => throwError(() => new Error(error.message))),
          tap((local_app) => {
            this.register_form.controls.licenseclass.setValue(
              local_app.licenseClassID
            );
          }),
          switchMap((local_app) => {
            return this.applicationService.read(local_app.applicationID).pipe(
              catchError((error) => throwError(() => new Error(error.message))),
              switchMap((mainApp) => {
                return this.personService.read(mainApp.personID).pipe(
                  catchError((error) =>
                    throwError(() => new Error(error.message))
                  ),
                  tap((person_info) => {
                    this.assignPerson(person_info);
                  })
                );
              })
            );
          })
        )
        .subscribe({
          next: () => {},
          error: (error) => {
            this.notificationSerice.showMessage({
              message: error.message,
              status: 'failed',
            });
          },
        });
      this.destroyRef.onDestroy(() => subscription.unsubscribe());
    }
  }

  assignPerson(person_info: Person) {
    const stringDate = new Date(person_info.birthDate)
      .toISOString()
      .split('T')[0];

    this.register_form.controls.firstname.setValue(person_info.firstName);
    this.register_form.controls.secondname.setValue(person_info.secondName);
    this.register_form.controls.thirdname.setValue(person_info.thirdName);
    this.register_form.controls.lastname.setValue(person_info.lastName);
    this.register_form.controls.email.setValue(person_info.email);
    this.register_form.controls.nationalno.setValue(person_info.nationalNumber);
    this.register_form.controls.birthdate.setValue(new Date(stringDate));
    this.register_form.controls.phonenumber.setValue(person_info.phoneNumber);
    this.register_form.controls.country.setValue(person_info.nationality);
    this.register_form.controls.address.setValue(person_info.address);
    this.register_form.controls.gender.setValue(
      person_info.gender == 'Male' ? 'Male' : 'Female'
    );
    // this.register_form.controls.img.setValue(
    //   person_info.personalPicture ? person_info.personalPicture.toString() : ''
    // );
  }

  onSubmit() {
    this.isDialogVisible.set(false);
    const currentUser = this.currentUserSerice.getCurrentUser();
    if (!currentUser) {
      const notify: NotificationBox = {
        message: `Current user session might end, login again!`,
        status: 'failed',
      };
      this.notificationSerice.showMessage(notify);
      return;
    }

    if (this.register_form.valid) {
      this.isDialogVisible.set(true);
      //new person/application/local application in ADD MODE
      if (this.isConfirmed() && this.application_mode == enMode.add) {
        let new_person: Person = {
          id: 0,
          firstName: this.register_form.controls.firstname.value!,
          secondName: this.register_form.controls.secondname.value!,
          thirdName: this.register_form.controls.thirdname.value!,
          lastName: this.register_form.controls.lastname.value!,
          nationalNumber: this.register_form.controls.nationalno.value!,
          phoneNumber: this.register_form.controls.phonenumber.value!,
          address: this.register_form.controls.address.value!,
          birthDate: new Date(this.register_form.controls.birthdate.value!)
            .toISOString()
            .split('T')[0],
          email: this.register_form.controls.email.value!,
          gender: this.register_form.controls.gender.value!,
          nationality: this.register_form.controls.country.value!,
          personalPicture: this.register_form.controls.img.value!,
          creationDate: this.current_date,
          createdByUserID: this.currentUserSerice.getCurrentUser()!.id,
          updatedByUserID: null,
          updatedDate: null,
        };
        let new_app: Application = {
          id: 0,
          personID: 0,
          status: 1,
          type: 1,
          date: this.current_date,
          paidFees: this.application_types.at(0)!.typeFee,
          lastStatusDate: this.current_date,
          createdByUserID: this.currentUserSerice.getCurrentUser()!.id,
        };
        let local_app: LocalApplication = {
          id: 0,
          applicationID: 0,
          licenseClassID: +this.register_form.controls.licenseclass.value!,
        };
        const subscription = this.licenseClassService
          .getLicenseClass(local_app.licenseClassID)
          .pipe(
            switchMap((response) => {
              const birthdate = new Date(new_person.birthDate);
              const age =
                this.current_date.getFullYear() - birthdate.getFullYear();
              if (response.minAgeAllowed > age) {
                return throwError(
                  () =>
                    new Error(
                      `'Age restriction not met! must be older than ${response.minAgeAllowed}`
                    )
                );
              } else {
                return this.personService.create(new_person);
              }
            }),
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
            }),
            catchError((error) => {
              return throwError(() => error);
            })
          )
          .subscribe({
            next: (res) => {
              const notify: NotificationBox = {
                message: `Application saved successfully, Application ID = ${res.id} :)`,
                status: 'success',
              };
              this.notificationSerice.showMessage(notify);
            },
            error: (err) => {
              const notify: NotificationBox = {
                message: `${err.message}`,
                status: 'failed',
              };
              this.notificationSerice.showMessage(notify);
            },
            complete: () => {},
          });
        this.destroyRef.onDestroy(() => subscription.unsubscribe());
      }
    }
  }
  onClosed() {
    this.closed.emit(true);
  }
}

// The error appears in the canDeactivate function.
// If canDeactivate directly references window, it will fail during SSR.
export const canDeactivate: CanDeactivateFn<NewLocalApplicationComponent> = (
  component,
  currentRoute,
  currentState,
  nextState
) => {
  const platformId = inject(PLATFORM_ID);
  if (isPlatformBrowser(platformId) && component.register_form.dirty) {
    return window.confirm(
      'Are you sure you want to leave? Unsaved changes will be lost.'
    );
  }
  return true;
};
