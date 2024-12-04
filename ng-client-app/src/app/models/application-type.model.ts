export interface ApplicationType {
  id: number;
  typeName: string;
  typeFees: number;
}

export const ApplicationTypes: ApplicationType[] = [
  {
    id: 1,
    typeName: 'New Local Driving License Services',
    typeFees: 15,
  },
  {
    id: 2,
    typeName: 'Renew Driving License Service',
    typeFees: 5,
  },
  {
    id: 3,
    typeName: 'Replacement for Lost Driving License',
    typeFees: 10,
  },
  {
    id: 4,
    typeName: 'Replacement for Damaged Driving License',
    typeFees: 5,
  },
  {
    id: 5,
    typeName: 'Release Detained Driving License',
    typeFees: 15,
  },
  {
    id: 6,
    typeName: 'New International License',
    typeFees: 50,
  },
  {
    id: 7,
    typeName: 'Retake Test',
    typeFees: 5,
  },
];
