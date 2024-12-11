import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationTypesComponent } from './application-types.component';

describe('ApplicationTypesComponent', () => {
  let component: ApplicationTypesComponent;
  let fixture: ComponentFixture<ApplicationTypesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ApplicationTypesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApplicationTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
