import { ComponentFixture, TestBed } from '@angular/core/testing';
import { InternationalLicensesComponent } from './international-licenses.component';
describe('InternationalLicensesComponent', () => {
  let component: InternationalLicensesComponent;
  let fixture: ComponentFixture<InternationalLicensesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InternationalLicensesComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(InternationalLicensesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
