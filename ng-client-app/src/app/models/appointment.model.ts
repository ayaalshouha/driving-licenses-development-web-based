export interface Appointment {
  id: number;
  date: Date;
  paidFees: number;
  isLocked: boolean;
  testType: number;
  localLicenseApplicationID: number;
  createdByUserID: number;
  retakeTestID: number | null;
}

export interface Appointment_View {
  testType: number;
  localLicenseApplicationID: number;
  fullName: string;
  id: number;
  date: Date;
  paidFees: number;
  isLocked: boolean;
}
