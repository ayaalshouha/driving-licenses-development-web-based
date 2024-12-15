export interface LicenseClass {
  id: number;
  className: string;
  description: string;
  fees: number;
  minAgeAllowed: number;
  validityYears: number;
}

export enum enLicenseClass {
  '1st Class - Small Motorcycle' = 1,
  '2nd Class - Heavy Motorcycle',
  '3rd Class - Ordinary Driving License',
  '4th Class - Commerical',
  '5th Class - Agricultural',
  '6th Class - Small and Medium Bus',
  '7th Class - Truck and Heavy Vehicle',
}
