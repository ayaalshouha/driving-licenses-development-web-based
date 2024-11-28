import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewLocalApplicationComponent } from './new-local-application.component';

describe('NewLocalApplicationComponent', () => {
  let component: NewLocalApplicationComponent;
  let fixture: ComponentFixture<NewLocalApplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NewLocalApplicationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewLocalApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
