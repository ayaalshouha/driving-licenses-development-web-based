export interface Application {
  id: number;
  personID: number;
  status: enApplicationStatus;
  type: enApplicationType;
  date: Date;
  paidFees: number;
  lastStatusDate: Date;
  createdByUserID: number;
}

export enum enApplicationStatus {
  'New' = 1,
  'Cancelled',
  'Completed',
}

export enum enApplicationType {
  'New Local Driving License Services' = 1,
  'Renew Driving License Service',
  'Replacement for Lost Driving License',
  'Replacement for Damaged Driving License',
  'Release Detained Driving License',
  'Retake Test',
}
