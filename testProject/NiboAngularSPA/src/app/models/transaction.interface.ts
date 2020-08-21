import { DecimalPipe } from '@angular/common';
import { AccountModel } from './account.interface';

export interface Transaction {
  id: number;
  transactionType: string;
  transactionValue: number;
  description: string;
  accountId: number;
  datePosted: Date;

  account: AccountModel;
}

export class TransactionModel {
  id: number;
  transactionType: string;
  transactionValue: number;
  description: string;
  accountId: number;
  datePosted: Date;

  account: AccountModel;
}
