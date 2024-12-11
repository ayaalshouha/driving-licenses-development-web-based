export interface Driver {
  id: number;
  personID: number;
  creationDate: Date;
  createdByUserID: number;
}

export interface Driver_View {
  id: number;
  personID: number;
  fullName: string;
  nationalID: string;
  date: Date;
  activeLicenses: number;
}
