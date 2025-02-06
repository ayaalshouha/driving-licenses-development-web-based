import { Component } from '@angular/core';
import { DialogWrapperComponent } from '../../../shared/dialog-wrapper/dialog-wrapper.component';
import { Location } from '@angular/common';
@Component({
  selector: 'app-change-password',
  standalone: true,
  imports: [DialogWrapperComponent],
  templateUrl: './change-password.component.html',
  styleUrl: './change-password.component.css',
})
export class ChangePasswordComponent {
  constructor(private location: Location) {}
  get invalidPassword() {
    return true;
  }
  onChange() {}
  onCancel() {
    this.location.back();
  }
}
