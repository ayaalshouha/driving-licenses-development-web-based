import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestsManagementComponent } from './tests-management.component';

describe('TestsManagementComponent', () => {
  let component: TestsManagementComponent;
  let fixture: ComponentFixture<TestsManagementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TestsManagementComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TestsManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
