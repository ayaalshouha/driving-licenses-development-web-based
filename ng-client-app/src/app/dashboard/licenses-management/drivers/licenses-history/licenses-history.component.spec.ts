import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LicensesHistoryComponent } from './licenses-history.component';

describe('LicensesHistoryComponent', () => {
  let component: LicensesHistoryComponent;
  let fixture: ComponentFixture<LicensesHistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LicensesHistoryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LicensesHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
