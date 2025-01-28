import { Component } from '@angular/core';
import { AddEditApplicationComponent } from "../applications-management/add-edit-application/add-edit-application.component";
import { NewLocalApplicationComponent } from "../services/new-local-application/new-local-application.component";

@Component({
  selector: 'app-user-account',
  standalone: true,
  imports: [ NewLocalApplicationComponent],
  templateUrl: './user-account.component.html',
  styleUrl: './user-account.component.css'
})
export class UserAccountComponent {

}
