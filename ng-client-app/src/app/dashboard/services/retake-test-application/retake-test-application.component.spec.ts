import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RetakeTestApplicationComponent } from './retake-test-application.component';

describe('RetakeTestApplicationComponent', () => {
  let component: RetakeTestApplicationComponent;
  let fixture: ComponentFixture<RetakeTestApplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RetakeTestApplicationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RetakeTestApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
