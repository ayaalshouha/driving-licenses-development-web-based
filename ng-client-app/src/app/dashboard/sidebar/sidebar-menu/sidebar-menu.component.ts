import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-sidebar-menu',
  standalone: true,
  imports: [],
  templateUrl: './sidebar-menu.component.html',
  styleUrl: './sidebar-menu.component.css',
})
export class SidebarMenuComponent {
  services_menuOpen = signal(false);
  apps_menuOpen = signal(false);
  license_menuOpen = signal(false);
  system_menuOpen = signal(false);

  services_toggle() {
    console.log(this.services_menuOpen());
    this.services_menuOpen.set(!this.services_menuOpen());
  }
  apps_toggle() {
    console.log(this.apps_menuOpen());
    this.apps_menuOpen.set(!this.apps_menuOpen());
  }
  licenses_toggle() {
    console.log(this.license_menuOpen());
    this.license_menuOpen.set(!this.license_menuOpen());
  }
  system_toggle() {
    console.log(this.system_menuOpen());
    this.system_menuOpen.set(!this.system_menuOpen());
  }
}
