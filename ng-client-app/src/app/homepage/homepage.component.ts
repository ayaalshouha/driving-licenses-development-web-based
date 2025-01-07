import { Component } from '@angular/core';
import { HeaderComponent } from './header/header.component';
import { LandingComponent } from './landing/landing.component';
import { ServicesSectionComponent } from './services-section/services-section.component';
import { ProcessSectionComponent } from './process-section/process-section.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { RouterOutlet } from '@angular/router';
@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [
    HeaderComponent,
    LandingComponent,
    ServicesSectionComponent,
    ProcessSectionComponent,
    AboutUsComponent,
  ],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css',
})
export class HomepageComponent {}
