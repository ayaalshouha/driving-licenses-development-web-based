import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProcessSectionComponent } from './process-section.component';

describe('ProcessSectionComponent', () => {
  let component: ProcessSectionComponent;
  let fixture: ComponentFixture<ProcessSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProcessSectionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProcessSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
