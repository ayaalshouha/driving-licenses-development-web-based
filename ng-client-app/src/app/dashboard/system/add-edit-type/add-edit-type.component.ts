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
  current_app_type: ApplicationType | undefined = undefined;
  current_test_type: TestType | undefined = undefined;
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
    // this.initializeMode();
  }

  AddEditApplication() {
    if (this.type == 'application') {
      if (this.mode == 'add') {
        this.current_app_type = {
          id: 0,
          typeTitle: this.type_form.controls.typeTitle.value!,
          typeFee: this.type_form.controls.typeFees.value!,
        };
        this.applicationTypeServ.add();
      } else {
      }
    }
  }

  AddEditProcess() {
    if (this.mode == 'add') {
      if (this.type == 'application') {
        //add application type
      } else {
        //add test type
      }
    } else {
      if (this.type == 'application') {
        //edit application type
      } else {
        //edit test type
      }
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
