import { Component } from '@angular/core';
import { DialogWrapperComponent } from '../../../shared/dialog-wrapper/dialog-wrapper.component';

@Component({
  selector: 'app-preview-application',
  standalone: true,
  imports: [DialogWrapperComponent],
  templateUrl: './preview-application.component.html',
  styleUrl: './preview-application.component.css',
})
export class PreviewApplicationComponent {}
