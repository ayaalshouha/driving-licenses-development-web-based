import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewInternationalApplicationComponent } from './new-international-application.component';

describe('NewInternationalApplicationComponent', () => {
  let component: NewInternationalApplicationComponent;
  let fixture: ComponentFixture<NewInternationalApplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NewInternationalApplicationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewInternationalApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
