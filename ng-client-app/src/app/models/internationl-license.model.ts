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

export interface ShortInternationalLicense {
  licenseID: number;
  applicationID: number;
  issuedUsingLocalLicenseID: number;
  issueDate: Date;
  expirationDate: Date;
  isActive: boolean;
}
