export interface License {
  id: number;
  applicationID: number;
  driverID: number;
  licenseClass: number;
  issueDate: Date;
  expDate: Date;
  isActive: boolean;
  paidFees: number;
  issueReason: enIssueReason;
  notes: string;
  createdByUserID: number;
}

export enum enIssueReason {
  FirstTime = 1,
  Renew,
  DamagedReplacement,
  LostReplacement,
}
