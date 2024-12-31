import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { NewLocalApplicationComponent } from '../../services/new-local-application/new-local-application.component';
import { ActivatedRoute } from '@angular/router';
import { DialogWrapperComponent } from '../../../shared/dialog-wrapper/dialog-wrapper.component';
import { Location } from '@angular/common';
@Component({
  selector: 'app-add-edit-application',
  standalone: true,
  imports: [NewLocalApplicationComponent, DialogWrapperComponent],
  templateUrl: './add-edit-application.component.html',
  styleUrl: './add-edit-application.component.css',
})
export class AddEditApplicationComponent implements OnInit {
  mode: string | null = null;
  application_id: number | null = null;
  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private cdr: ChangeDetectorRef
  ) {}
  ngOnInit(): void {
    console.log('from add edit app - application id = ' + this.application_id);
    this.route.queryParams.subscribe((params) => {
      this.mode = params['mode'];
      this.application_id = +params['application_id'];
    });
    this.cdr.detectChanges();
  }

  onClose(closed: boolean) {
    if (closed) {
      this.location.back();
    }
  }
}
