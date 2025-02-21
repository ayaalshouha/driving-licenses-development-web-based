import { Component } from '@angular/core';
import { DialogWrapperComponent } from '../../../shared/dialog-wrapper/dialog-wrapper.component';
import { Location } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
@Component({
  selector: 'app-change-password',
  standalone: true,
  imports: [DialogWrapperComponent, FormsModule],
  templateUrl: './change-password.component.html',
  styleUrl: './change-password.component.css',
})
export class ChangePasswordComponent {
  constructor(private location: Location) {}
  get invalidPassword() {
    return true;
  }
  onSubmit(form: NgForm) {
    
  }
  onCancel() {
    this.location.back();
  }
}
