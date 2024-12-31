import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditApplicationComponent } from './add-edit-application.component';

describe('AddEditApplicationComponent', () => {
  let component: AddEditApplicationComponent;
  let fixture: ComponentFixture<AddEditApplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddEditApplicationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
