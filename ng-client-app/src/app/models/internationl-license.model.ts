export interface InternationalLicense {
  id: number;
  applicationID: number;
  driverID: number;
  issuedByLocalLicenseID: number;
  issueDate: Date;
  expDate: Date;
  isActive: boolean;
  createdByUserID: number;
}
