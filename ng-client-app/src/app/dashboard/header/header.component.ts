import { Component, inject, Inject, signal } from '@angular/core';
import { CurrentUserService } from '../../services/current-user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
})
export class HeaderComponent {
  currentUserService = inject(CurrentUserService);
  private router = inject(Router);

  menuOpen = signal<boolean>(false);
  constructor() {}

  toggleMenu() {
    this.menuOpen.set(!this.menuOpen());
  }

  logout() {
    // localStorage.removeItem('authToken');
    this.currentUserService.setCurrentUser(undefined);
    this.router.navigate(['/login']);
  }
}
