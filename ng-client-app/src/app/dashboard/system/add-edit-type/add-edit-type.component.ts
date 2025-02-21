import {
  ChangeDetectorRef,
  Component,
  Input,
  OnInit,
  signal,
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { NotificationService } from '../../../services/notification.service';
import { ApplicationTypesService } from '../../../services/application-type.service';
import { TestTypesService } from '../../../services/test-type.service';
import { ApplicationType } from '../../../models/application-type.model';
import { TestType } from '../../../models/test-type.model';
import { NotificationComponent } from '../../../shared/notification/notification.component';
import { DialogWrapperComponent } from '../../../shared/dialog-wrapper/dialog-wrapper.component';
import { ConfirmationDialogComponent } from '../../../shared/confirmation-dialog/confirmation-dialog.component';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { catchError, tap, throwError } from 'rxjs';
@Component({
  selector: 'app-add-edit-type',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    NotificationComponent,
    DialogWrapperComponent,
    ConfirmationDialogComponent,
  ],
  templateUrl: './add-edit-type.component.html',
  styleUrl: './add-edit-type.component.css',
})
export class AddEditTypeComponent implements OnInit {
  @Input() id: number | null = null;
  @Input() mode: 'add' | 'edit' | null = null;
  @Input() type: 'application' | 'test' | null = null;
  current_app_type = signal<ApplicationType | undefined>(undefined);
  current_test_type = signal<TestType | undefined>(undefined);
  isDialogVisible = signal<boolean>(false);

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private notifyService: NotificationService,
    private applicationTypeServ: ApplicationTypesService,
    private testTypeServ: TestTypesService,
    private cdRef: ChangeDetectorRef
  ) {}

  type_form = new FormGroup({
    typeTitle: new FormControl('', {
      validators: [Validators.required],
    }),
    typeFees: new FormControl(0, {
      validators: [Validators.required],
    }),
    typeDescription: new FormControl('', {
      validators: [Validators.required],
    }),
  });

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.id = params['id'];
      this.mode = params['mode'];
      this.type = params['type'];
    });
    this.cdRef.detectChanges();
    this.RetrievingOnEdit();
  }

  RetrievingOnEdit() {
    if (this.type == 'test' && this.mode == 'edit') {
      //retrieve test type
      this.testTypeServ
        .get(this.id!)
        .pipe(
          tap((response) => {
            this.current_test_type.set(response);
            this.type_form.controls.typeTitle.setValue(response.typeTitle);
            this.type_form.controls.typeFees.setValue(response.fees);
            this.type_form.controls.typeDescription.setValue(
              response.description
            );
          })
        )
        .subscribe({
          error: (error) =>
            this.notifyService.showMessage({
              message: error.message,
              status: 'failed',
            }),
        });
    } else if (this.type == 'application' && this.mode == 'edit') {
      // retrieve application type
      this.applicationTypeServ
        .get(this.id!)
        .pipe(
          tap((response) => {
            this.current_app_type.set(response);
            this.type_form.controls.typeTitle.setValue(response.typeTitle);
            this.type_form.controls.typeFees.setValue(response.typeFee);
          })
        )
        .subscribe({
          error: (error) =>
            this.notifyService.showMessage({
              message: error.message,
              status: 'failed',
            }),
        });
    }
  }

  AddEditApplication() {
    this.isDialogVisible.set(false);
    if (this.type == 'application') {
      this.current_app_type.set({
        id: 0,
        typeTitle: this.type_form.controls.typeTitle.value!,
        typeFee: this.type_form.controls.typeFees.value!,
      });
      if (this.mode == 'add') {
        this.applicationTypeServ
          .add(this.current_app_type()!)
          .pipe(
            catchError((error) => {
              return throwError(() => new Error(error.message));
            }),
            tap((response) => {
              if (response) {
                this.current_app_type.set(response);
                this.mode = 'edit';
              }
            })
          )
          .subscribe({
            next: () => {
              this.notifyService.showMessage({
                message: 'Type Added Successfully.',
                status: 'success',
              });
            },
            error: (error) => {
              this.notifyService.showMessage({
                message: error.message,
                status: 'failed',
              });
            },
          });
      } else {
        this.applicationTypeServ
          .update(this.id!, this.current_app_type()!)
          .pipe(
            catchError((error) => {
              return throwError(() => new Error(error.message));
            }),
            tap((response) => {
              if (response) {
                this.current_app_type.set(response);
              }
            })
          )
          .subscribe({
            next: () => {
              this.notifyService.showMessage({
                message: 'Type Updatted Successfully.',
                status: 'success',
              });
            },
            error: (error) => {
              this.notifyService.showMessage({
                message: error.message,
                status: 'failed',
              });
            },
          });
      }
    }
  }

  AddEditTest() {
    if (this.type == 'test') {
      this.current_test_type.set({
        id: 0,
        typeTitle: this.type_form.controls.typeTitle.value!,
        fees: this.type_form.controls.typeFees.value!,
        description: this.type_form.controls.typeDescription.value!,
      });

      if (this.mode == 'add') {
        this.testTypeServ
          .add(this.current_test_type()!)
          .pipe(
            catchError((error) => {
              return throwError(() => new Error(error.message));
            }),
            tap((response) => {
              if (response) {
                this.current_test_type.set(response);
                this.mode = 'edit';
              }
            })
          )
          .subscribe({
            next: () => {
              this.notifyService.showMessage({
                message: 'Type Added Successfully.',
                status: 'success',
              });
            },
            error: (error) => {
              this.notifyService.showMessage({
                message: error.message,
                status: 'failed',
              });
            },
          });
      } else {
        this.testTypeServ
          .update(this.id!, this.current_test_type()!)
          .pipe(
            catchError((error) => {
              return throwError(() => new Error(error.message));
            }),
            tap((response) => {
              if (response) {
                this.current_test_type.set(response);
              }
            })
          )
          .subscribe({
            next: () => {
              this.notifyService.showMessage({
                message: 'Type Updatted Successfully.',
                status: 'success',
              });
            },
            error: (error) => {
              this.notifyService.showMessage({
                message: error.message,
                status: 'failed',
              });
            },
          });
      }
    }
  }

  AddEditProcess() {
    if (this.type == 'application') {
      this.AddEditApplication();
    } else if (this.type == 'test') {
      this.AddEditTest();
    }
  }

  onDialogResult(confirmed: boolean) {
    this.isDialogVisible.set(false);
    if (confirmed) {
      this.AddEditProcess();
    }
  }

  onSubmit() {
    this.isDialogVisible.set(true);
  }
  onClose() {
    this.location.back();
  }
}
