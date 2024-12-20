import { Component, signal, ViewEncapsulation } from '@angular/core';
import { TestService } from '../../services/test.service';
import { DriverService } from '../../services/driver.service';

@Component({
  selector: 'app-test',
  standalone: true,
  imports: [],
  templateUrl: './test.component.html',
  styleUrl: './test.component.css',
  encapsulation: ViewEncapsulation.Emulated,
})
export class TestComponent {
  testCount = signal<number>(0);
  driversCount = signal<number>(0);
  licensesCount = signal<number>(0);

  constructor(
    private testService: TestService,
    private driverService: DriverService
  ) {}
}
