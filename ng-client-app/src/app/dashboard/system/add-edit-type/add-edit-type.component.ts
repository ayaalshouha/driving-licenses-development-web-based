import { Component, Input, OnInit, signal } from '@angular/core';
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
import { error } from 'console';
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
  @Input() typeID: number | null = null;
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
    private testTypeServ: TestTypesService
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
      this.typeID = params['id'];
      this.mode = params['mode'];
      this.type = params['type'];
    });
    console.log(this.typeID);
    console.log(this.mode);
    console.log(this.type);
  }

  AddEditApplication() {
    if (this.type == 'application') {
      if (this.mode == 'add') {
        this.current_app_type.set({
          id: 0,
          typeTitle: this.type_form.controls.typeTitle.value!,
          typeFee: this.type_form.controls.typeFees.value!,
        });
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
      }
    }
  }

  AddEditTest() {
    if (this.type == 'test') {
      if (this.mode == 'add') {
        this.current_test_type.set({
          id: 0,
          typeTitle: this.type_form.controls.typeTitle.value!,
          fees: this.type_form.controls.typeFees.value!,
          description: this.type_form.controls.typeDescription.value!,
        });
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
