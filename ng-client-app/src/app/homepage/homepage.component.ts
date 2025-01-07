import { Component } from '@angular/core';
import { HeaderComponent } from './header/header.component';
import { LandingComponent } from './landing/landing.component';
import { ServicesSectionComponent } from './services-section/services-section.component';
import { ProcessSectionComponent } from './process-section/process-section.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { RouterOutlet } from '@angular/router';
import { ContactUsComponent } from "./contact-us/contact-us.component";
@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [
    HeaderComponent,
    LandingComponent,
    ServicesSectionComponent,
    ProcessSectionComponent,
    AboutUsComponent,
    ContactUsComponent
],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css',
})
export class HomepageComponent {}
