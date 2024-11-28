import { Component, signal } from '@angular/core';
import { application } from 'express';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css',
})
export class SidebarComponent {
  menuOpen: { [key: string]: boolean } = {
    applications: false,
    reports: false,
  };

  toggleMenu(menu: string): void {
    console.log(this.menuOpen[menu]);
    this.menuOpen[menu] = !this.menuOpen[menu];
  }
}
