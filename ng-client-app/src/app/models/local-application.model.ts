export interface LocalApplication {
  id: number;
  applicationID: number;
  licenseClassID: number;
}

export interface LocalApplicationView {
  id: number;
  nationalID: string;
  class: string;
  fullName: string;
  date: string;
  passedTest: number;
  status: string;
}
