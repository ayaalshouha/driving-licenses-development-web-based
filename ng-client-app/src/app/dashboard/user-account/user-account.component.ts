import { Component, Inject, OnInit, PLATFORM_ID } from '@angular/core';
import { NewLocalApplicationComponent } from '../services/new-local-application/new-local-application.component';
import { isPlatformBrowser } from '@angular/common';
import { User } from '../../models/user.model';
import { PersonService } from '../../services/person.service';
import { ChangeDetectorRef } from '@angular/core';
import { UserService } from '../../services/user.service';
@Component({
  selector: 'app-user-account',
  standalone: true,
  imports: [NewLocalApplicationComponent],
  templateUrl: './user-account.component.html',
  styleUrl: './user-account.component.css',
})
export class UserAccountComponent implements OnInit {
  current_user: User | null = null;
  person_id: number | null = null;
  full_name: string | undefined = undefined;
  constructor(
    @Inject(PLATFORM_ID) private platformId: Object,
    private personService: PersonService,
    private userService: UserService,
    private cd: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    if (isPlatformBrowser(this.platformId)) {
      const current_user = localStorage.getItem('current-user');
      if (current_user) {
        try {
          const user = JSON.parse(current_user);
          this.current_user = user;
          this.person_id = user.personID;
          console.log('current user is done ', this.current_user?.personID);

          if (this.person_id) {
            this.personService.getFullName(this.person_id).subscribe({
              next: (response) => {
                this.full_name = response;
                console.log('Full Name:', this.full_name);
              },
              error: (err) => console.error('Error fetching full name:', err),
            });
          }
          this.cd.detectChanges();
        } catch (error) {
          console.error('Error parsing user data from local storage:', error);
        }
      }
    }
  }
}
