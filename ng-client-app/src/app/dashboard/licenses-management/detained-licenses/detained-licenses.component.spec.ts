import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetainedLicensesComponent } from './detained-licenses.component';

describe('LicensesComponent', () => {
  let component: DetainedLicensesComponent;
  let fixture: ComponentFixture<DetainedLicensesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DetainedLicensesComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(DetainedLicensesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
