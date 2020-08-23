export interface TransactionType {
  transactionTypeId: number;
  transactionTypeDesc: string;
}

export class TransactionTypeModel implements TransactionType {
  transactionTypeId: number;
  transactionTypeDesc: string;
}
