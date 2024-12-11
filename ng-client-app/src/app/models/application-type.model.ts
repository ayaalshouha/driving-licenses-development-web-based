export interface ApplicationType {
  id: number;
  typeTitle: string;
  typeFee: number;
}

export const ApplicationTypes: ApplicationType[] = [
  {
    id: 1,
    typeTitle: 'New Local Driving License Services',
    typeFee: 15,
  },
  {
    id: 2,
    typeTitle: 'Renew Driving License Service',
    typeFee: 5,
  },
  {
    id: 3,
    typeTitle: 'Replacement for Lost Driving License',
    typeFee: 10,
  },
  {
    id: 4,
    typeTitle: 'Replacement for Damaged Driving License',
    typeFee: 5,
  },
  {
    id: 5,
    typeTitle: 'Release Detained Driving License',
    typeFee: 15,
  },
  {
    id: 6,
    typeTitle: 'New International License',
    typeFee: 50,
  },
  {
    id: 7,
    typeTitle: 'Retake Test',
    typeFee: 5,
  },
];
