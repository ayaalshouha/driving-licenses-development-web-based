export interface Test {
  id: number;
  appointmentID: number;
  result: boolean;
  notes: string | null;
  createdByUserID: number;
}
