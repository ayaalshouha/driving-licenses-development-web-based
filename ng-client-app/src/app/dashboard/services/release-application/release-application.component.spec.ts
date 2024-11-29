import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReleaseApplicationComponent } from './release-application.component';

describe('ReleaseApplicationComponent', () => {
  let component: ReleaseApplicationComponent;
  let fixture: ComponentFixture<ReleaseApplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReleaseApplicationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReleaseApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
