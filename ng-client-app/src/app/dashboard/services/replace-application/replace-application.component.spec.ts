import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReplaceApplicationComponent } from './replace-application.component';

describe('ReplaceApplicationComponent', () => {
  let component: ReplaceApplicationComponent;
  let fixture: ComponentFixture<ReplaceApplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReplaceApplicationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReplaceApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
