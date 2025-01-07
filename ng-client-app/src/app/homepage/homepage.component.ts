import { Component } from '@angular/core';
import { HeaderComponent } from './header/header.component';
import { LandingComponent } from './landing/landing.component';
import { ServicesSectionComponent } from './services-section/services-section.component';
import { ProcessSectionComponent } from './process-section/process-section.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { FooterComponent } from "./footer/footer.component";
@Component({
  selector: 'app-homepage',
  standalone: true,
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css',
  imports: [HeaderComponent, LandingComponent, ProcessSectionComponent, ServicesSectionComponent, ContactUsComponent, AboutUsComponent, FooterComponent],
})
export class HomepageComponent {}
