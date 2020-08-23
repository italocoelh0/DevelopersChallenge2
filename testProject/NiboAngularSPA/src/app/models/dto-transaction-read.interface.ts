export interface DtoTransactionRead{
  accountId? : number | null;
  transactionTypeId : number | null;
  initialDateInterval? : Date | null;
  finalDateInterval? : Date | null;
}

export class DtoTransactionReadModel implements DtoTransactionRead{
  accountId? : number | null;
  transactionTypeId : number | null;
  initialDateInterval? : Date | null;
  finalDateInterval? : Date | null;
}
