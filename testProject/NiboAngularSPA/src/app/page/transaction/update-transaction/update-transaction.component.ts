import { Component, OnInit, Inject } from '@angular/core';
import { DtoDefaultResponse } from 'src/app/models/dto-default-response.interface';
import { Account, AccountModel } from 'src/app/models/account.interface';
import { TransactionType } from 'src/app/models/transactiontypes.interface';
import { CreateTransactionComponent } from '../create-transaction/create-transaction.component';
import { TransactionModel, Transaction } from 'src/app/models/transaction.interface';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AppService } from 'src/app/services/app.service';

@Component({
  selector: 'NiboAngularSPA-update-transaction',
  templateUrl: './update-transaction.component.html',
  styleUrls: ['./update-transaction.component.css']
})
export class UpdateTransactionComponent implements OnInit {
  transactionObj: Transaction = new TransactionModel
  transactionTypesObj: Array<TransactionType> = new Array<TransactionType>()
  accountsObj: Array<Account> = new Array<AccountModel>()

  transTypeId: string
  transValue: string
  accId: string
  desc: string

  constructor(@Inject(MAT_DIALOG_DATA) public _data: Transaction, private _dialRef: MatDialogRef<CreateTransactionComponent>, private _appService: AppService) { }

  ngOnInit(): void {
    if(this._data != undefined && this._data != null){
      this.transTypeId = this._data.transactionTypeId.toString()
      this.transValue = this._data.transactionValue.toString()
      this.accId = this._data.accountId.toString()
      this.desc = this._data.description
    }
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
      this.transactionObj.id = this._data.id

      this._appService.postItems('Transaction/updateTransaction', this.transactionObj).subscribe((response: DtoDefaultResponse) => {
        if (response != null && response != undefined)
          this.closeDialog(response.message)
      })
    }
  }

  closeDialog(value?) {
    return this._dialRef.close(value)
  }
}
