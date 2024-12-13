export interface Appointment {
  id: number;
  date: Date;
  paidFees: number;
  isLocked: boolean;
  testType: number;
  localLicenseApplicationID: number;
  createdByUserID: number;
  retakeTestID: number; 
}

export interface Appointment_View {
  id: number;
  date: Date;
  paidFees: number;
  isLocked: boolean;
  testType: number;
  localLicenseApplicationID: number;
}
