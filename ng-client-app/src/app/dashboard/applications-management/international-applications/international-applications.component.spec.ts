import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternationalApplicationsComponent } from './international-applications.component';

describe('InternationalApplicationsComponent', () => {
  let component: InternationalApplicationsComponent;
  let fixture: ComponentFixture<InternationalApplicationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InternationalApplicationsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InternationalApplicationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
