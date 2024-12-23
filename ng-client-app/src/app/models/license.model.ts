export interface License {
  id: number;
  applicationID: number;
  driverID: number;
  licenseClass: number;
  issueDate: Date;
  expDate: Date;
  isActive: boolean;
  paidFees: number;
  issueReason: number;
  notes: string | null;
  createdByUserID: number;
}

export enum enIssueReason {
  'First Time Issuance' = 1,
  'Renew License',
  'Damaged Replacement',
  'Lost Replacement',
}
