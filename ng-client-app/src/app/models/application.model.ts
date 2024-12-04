export interface Application {
  id: number;
  personID: number;
  status: 1 | 2 | 3;
  type: number;
  date: Date;
  paidFees: number;
  lastStatusDate: Date;
  createdByUserID: number;
}
