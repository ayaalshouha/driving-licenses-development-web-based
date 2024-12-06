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
    if (window.confirm('Are you sure you want to logout?')) {
      window.localStorage.setItem('current-user', JSON.stringify(undefined));
      this.router.navigate(['/login']);
    }
  }
}
