import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PreviewApplicationComponent } from './preview-application.component';

describe('PreviewApplicationComponent', () => {
  let component: PreviewApplicationComponent;
  let fixture: ComponentFixture<PreviewApplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PreviewApplicationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PreviewApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
