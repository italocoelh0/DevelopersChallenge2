import { Account } from './account.interface';
import { TransactionType } from './transactiontypes.interface';

export interface Transaction {
  id: number;
  transactionTypeId: number;
  transactionValue: number;
  description: string;
  accountId: number;
  datePosted: Date;

  account: Account;
  transactionType : TransactionType;
}

export class TransactionModel implements TransactionModel {
  id: number;
  transactionTypeId: number;
  transactionValue: number;
  description: string;
  accountId: number;
  datePosted: Date;

  account: Account;
  transactionType : TransactionType;
}
