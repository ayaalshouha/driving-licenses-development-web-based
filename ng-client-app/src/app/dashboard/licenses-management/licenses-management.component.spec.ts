import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LicensesManagementComponent } from './licenses-management.component';

describe('LicensesManagementComponent', () => {
  let component: LicensesManagementComponent;
  let fixture: ComponentFixture<LicensesManagementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LicensesManagementComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LicensesManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
