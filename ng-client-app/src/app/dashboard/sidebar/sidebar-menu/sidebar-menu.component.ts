import { Component, signal, WritableSignal } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
type MenuKeys = 'services' | 'apps' | 'licenses' | 'system' | 'new-app';

@Component({
  selector: 'app-sidebar-menu',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './sidebar-menu.component.html',
  styleUrl: './sidebar-menu.component.css',
})
export class SidebarMenuComponent {
  menuOpen: Record<MenuKeys, WritableSignal<boolean>> = {
    services: signal(false),
    apps: signal(false),
    licenses: signal(false),
    system: signal(false),
    'new-app': signal(false),
  };

  ontoggle(menu: MenuKeys) {
    this.menuOpen[menu].set(!this.menuOpen[menu]());
  }
}
