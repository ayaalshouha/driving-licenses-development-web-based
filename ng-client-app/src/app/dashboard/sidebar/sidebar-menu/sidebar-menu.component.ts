import { Component, inject, signal, WritableSignal } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
type MenuKeys =
  | 'services'
  | 'apps'
  | 'licenses'
  | 'system'
  | 'new-app'
  | 'appointments'
  | 'tests';

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
    appointments: signal(false),
    tests: signal(false),
  };
  constructor() {}
  private isParentOrChild(menuKey: MenuKeys, targetMenu: MenuKeys): boolean {
    const hierarchy: Record<MenuKeys, MenuKeys[]> = {
      services: ['new-app'],
      apps: [],
      licenses: [],
      system: [],
      'new-app': [],
      appointments: [],
      tests: [],
    };
    return (
      hierarchy[targetMenu]?.includes(menuKey) ||
      hierarchy[menuKey]?.includes(targetMenu)
    );
  }
  ontoggle(menu: MenuKeys) {
    for (const key in this.menuOpen) {
      if (key === menu) {
        // Toggle the target menu
        this.menuOpen[key as MenuKeys].set(!this.menuOpen[key as MenuKeys]());
      } else if (!this.isParentOrChild(key as MenuKeys, menu)) {
        // Close menus that are not parent or child of the target menu
        this.menuOpen[key as MenuKeys].set(false);
      }
    }
  }

  logout() {
    if (window.confirm('Are you sure you want to logout?')) {
      window.localStorage.setItem('current-user', JSON.stringify(undefined));
      this.router.navigate(['/login']);
    }
  }
}
