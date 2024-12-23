import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-confirmation-dialog',
  standalone: true,
  imports: [],
  templateUrl: './confirmation-dialog.component.html',
  styleUrl: './confirmation-dialog.component.css',
})
export class ConfirmationDialogComponent {
  @Input() isVisible = false;
  @Input() title = 'Confirm';
  @Input() message = 'Are you sure?';
  @Output() confirmed = new EventEmitter<boolean>();

  confirm() {
    console.log('Confirm clicked. Emitting true...');
    this.confirmed.emit(true);
    this.isVisible = false;
  }
  cancel() {
    console.log('Cancel clicked. Emitting false...');
    this.confirmed.emit(false);
    this.isVisible = false;
  }
}
