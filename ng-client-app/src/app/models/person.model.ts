export interface Person {
  id: number;
  firstName: string;
  secondName: string;
  thirdName: string;
  lastName: string;
  nationalNumber: string;
  address: string;
  email: string;
  phoneNumber: string;
  birthDate: string;
  personalPicture: string;
  nationality: string;
  gender: string;
  createdByUserID: number;
  creationDate: Date;
  updatedByUserID: number | null;
  updatedDate: Date | null;
}
