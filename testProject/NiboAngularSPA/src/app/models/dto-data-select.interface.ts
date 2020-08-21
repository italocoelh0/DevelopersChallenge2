export interface DtoDataSelect{
  accountId? : number | null;
  initialDateInterval? : Date | null;
  endDateInterval? : Date | null;
}

export class DataSelectModel implements DtoDataSelect{
  accountId? : number | null;
  initialDateInterval? : Date | null;
  endDateInterval? : Date | null;
}
