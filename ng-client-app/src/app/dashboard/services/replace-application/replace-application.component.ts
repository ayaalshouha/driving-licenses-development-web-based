import { Component } from '@angular/core';

enum enMode {
  damage = 1,
  lost,
}
@Component({
  selector: 'app-replace-application',
  standalone: true,
  imports: [],
  templateUrl: './replace-application.component.html',
  styleUrl: './replace-application.component.css',
})
export class ReplaceApplicationComponent {
  replace_mode: enMode = enMode.lost;
}
