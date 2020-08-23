import { Component, OnInit } from '@angular/core';
import { TransactionModel, Transaction } from 'src/app/models/transaction.interface';
import { AppService } from 'src/app/services/app.service';
import { MatDialogRef } from '@angular/material/dialog';
import { TransactionType } from 'src/app/models/transactiontypes.interface';
import { Account, AccountModel } from 'src/app/models/account.interface';
import { DtoDefaultResponse } from 'src/app/models/dto-default-response.interface';

@Component({
  selector: 'NiboAngularSPA-create-transaction',
  templateUrl: './create-transaction.component.html',
  styleUrls: ['./create-transaction.component.css']
})
export class CreateTransactionComponent implements OnInit {
  transactionObj: Transaction = new TransactionModel
  transactionTypesObj: Array<TransactionType> = new Array<TransactionType>()
  accountsObj: Array<Account> = new Array<AccountModel>()

  transTypeId: string
  transValue: string
  accId: string
  desc: string

  constructor(private _dialRef: MatDialogRef<CreateTransactionComponent>, private _appService: AppService) { }

  ngOnInit(): void {
    this.getTransTypes()
    this.getAccounts()
  }

  async getTransTypes() {
    this._appService.getItems('Transaction/getTypes').subscribe((response: Array<TransactionType>) => {
      if (response != null && response != undefined)
        this.transactionTypesObj = response
    })
  }
  async getAccounts() {
    this._appService.postItems('Account/readAccounts', new AccountModel).subscribe((response: Array<Account>) => {
      if (response != null && response != undefined)
        this.accountsObj = response
    })
  }

  onFormSubmit(valid) {
    if (valid) {
      this.transactionObj.datePosted = new Date()
      this.transactionObj.transactionTypeId = parseInt(this.transTypeId)
      this.transactionObj.transactionValue = parseFloat(this.transValue)
      this.transactionObj.accountId = parseInt(this.accId)
      this.transactionObj.description = this.desc

      this._appService.postItems('Transaction/createTransaction', this.transactionObj).subscribe((response: DtoDefaultResponse) => {
        if (response != null && response != undefined)
          this.closeDialog(response.message)
      })
    }
  }

  closeDialog(value?) {
    return this._dialRef.close(value)
  }
}
