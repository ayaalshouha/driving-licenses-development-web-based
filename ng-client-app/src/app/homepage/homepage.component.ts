import { Component } from '@angular/core';
import { HeaderComponent } from './header/header.component';
import { LandingComponent } from "./landing/landing.component";
import { ServicesSectionComponent } from "./services-section/services-section.component";
import { ProcessSectionComponent } from "./process-section/process-section.component";
@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [HeaderComponent, LandingComponent, ServicesSectionComponent, ProcessSectionComponent],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css',
})
export class HomepageComponent {}
