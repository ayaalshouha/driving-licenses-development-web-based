import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LocalApplicationsComponent } from './local-applications.component';

describe('LocalApplicationsComponent', () => {
  let component: LocalApplicationsComponent;
  let fixture: ComponentFixture<LocalApplicationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LocalApplicationsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LocalApplicationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
