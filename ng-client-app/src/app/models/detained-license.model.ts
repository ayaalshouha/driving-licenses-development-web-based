export interface DetainedLicense {
  id: number;
  fullName: string;
  licenseID: number;
  detainDate: Date;
  isReleased: boolean;
  fineFees: number;
  releaseDate: Date;
  nationalNo: string;
  releaseApplicationID: number;
}
