import { Component } from '@angular/core';
import { HeaderComponent } from './header/header.component';
import { LandingComponent } from "./landing/landing.component";
import { ServicesSectionComponent } from "./services-section/services-section.component";
@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [HeaderComponent, LandingComponent, ServicesSectionComponent],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css',
})
export class HomepageComponent {}
