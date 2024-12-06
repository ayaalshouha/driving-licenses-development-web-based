import { Component, inject, signal, WritableSignal } from '@angular/core';
import {
  CanDeactivateFn,
  Router,
  RouterLink,
  RouterLinkActive,
} from '@angular/router';
import { CurrentUserService } from '../../../services/current-user.service';
type MenuKeys = 'services' | 'apps' | 'licenses' | 'system' | 'new-app';

@Component({
  selector: 'app-sidebar-menu',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './sidebar-menu.component.html',
  styleUrl: './sidebar-menu.component.css',
})
export class SidebarMenuComponent {
  private router = inject(Router);
  menuOpen: Record<MenuKeys, WritableSignal<boolean>> = {
    services: signal(false),
    apps: signal(false),
    licenses: signal(false),
    system: signal(false),
    'new-app': signal(false),
  };
  constructor(private currentUserService: CurrentUserService) {}
  ontoggle(menu: MenuKeys) {
    this.menuOpen[menu].set(!this.menuOpen[menu]());
  }
  logout() {
    if (window.confirm('Are you sure you want to logout?')) {
      window.localStorage.setItem('current-user', JSON.stringify(undefined));
      this.router.navigate(['/login']);
    }
  }
}
