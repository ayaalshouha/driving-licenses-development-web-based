import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RenewLocalApplicationComponent } from './renew-local-application.component';

describe('RenewLocalApplicationComponent', () => {
  let component: RenewLocalApplicationComponent;
  let fixture: ComponentFixture<RenewLocalApplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RenewLocalApplicationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RenewLocalApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
