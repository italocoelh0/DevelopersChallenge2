export interface Account {
  accountId: number;
  accountType: string;
  bankId: number;
}

export class AccountModel implements Account{
  accountId: number;
  accountType: string;
  bankId: number;
}
