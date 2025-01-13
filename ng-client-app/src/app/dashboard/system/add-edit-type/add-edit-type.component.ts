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
@Component({
  selector: 'app-add-edit-type',
  standalone: true,
  imports: [
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
  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.typeID = params['id'];
      this.mode = params['mode'];
      this.type = params['type'];
    });

    this.initializeMode();
  }

  initializeMode() {
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
  onDialogResult(confirmed: boolean) {}

  onSubmit() {}
  onClose() {
    this.location.back();
  }
}
