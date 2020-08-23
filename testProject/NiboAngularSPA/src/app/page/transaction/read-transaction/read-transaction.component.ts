import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Transaction, TransactionModel } from 'src/app/models/transaction.interface';
import { AppService } from 'src/app/services/app.service'
import { DtoTransactionRead, DtoTransactionReadModel } from 'src/app/models/dto-transaction-read.interface';
import { TransactionType, TransactionTypeModel } from 'src/app/models/transactiontypes.interface';
import { PageEvent } from '@angular/material/paginator';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CreateTransactionComponent } from '../create-transaction/create-transaction.component';
import { ImportDataComponent } from '../../import-data/import-data.component';
import { DtoDefaultResponse } from 'src/app/models/dto-default-response.interface';
import { UpdateTransactionComponent } from '../update-transaction/update-transaction.component';

@Component({
  selector: 'NiboAngularSPA-read-transaction',
  templateUrl: './read-transaction.component.html',
  styleUrls: ['./read-transaction.component.css']
})
export class ReadTransactionComponent implements OnInit {
  transactionsObj: Array<Transaction> = new Array<TransactionModel>()
  filterObj: DtoTransactionRead = new DtoTransactionReadModel
  transTypeObj: Array<TransactionType> = new Array<TransactionTypeModel>()
  pagedResult: Array<Transaction>;

  transTypeId: string = "";
  pageSize: number;
  itensCount: number;

  constructor(private _appService: AppService, private _dial: MatDialog, private _msg: MatSnackBar) { }

  ngOnInit(): void {
    this.readTransactions()
    this.getDropOptions()
  }

  getDropOptions() {
    this._appService.getItems('Transaction/getTypes').subscribe((response: Array<TransactionType>) => {
      this.transTypeObj = response
    })
  }

  transTypeChanged($event) {
    this.filterObj.transactionTypeId = parseInt(this.transTypeId)
  }

  onPageChange(event: PageEvent) {
    const startIdx = event.pageIndex * event.pageSize
    let endIdx = startIdx + event.pageSize

    if (endIdx > event.length)
      endIdx = event.length

    this.pagedResult = this.transactionsObj.slice(startIdx, endIdx)
  }

  importFiles() {
    let dial = this._dial.open(ImportDataComponent, { maxWidth: '750px' });
    dial.afterClosed().subscribe(res => {
      if (res == null || res == undefined)
        return;
      else
        return this.readTransactions() ,this._msg.open(res, '', { duration: 2000, horizontalPosition: 'center', verticalPosition: 'top' });
    });
  }

  readTransactions() {
    this._appService.postItems('Transaction/readTransactions', this.filterObj).subscribe((response: Array<Transaction>) => {
      this.transactionsObj = response;
      this.pagedResult = this.transactionsObj.slice(0, 10)
    })
  }

  newTransaction() {
    let dial = this._dial.open(CreateTransactionComponent, { maxWidth: '750px' });
    dial.afterClosed().subscribe(res => {
      if (res == null || res == undefined)
        return;
      else {
        this._msg.open(res, '', { duration: 2000, horizontalPosition: 'center', verticalPosition: 'top' })
        return this.readTransactions()
      }
    });
  }

  editTransaction(transaction: Transaction) {
    let dial = this._dial.open(UpdateTransactionComponent, { maxWidth: '750px', data: { ...transaction } });
    dial.afterClosed().subscribe(res => {
      if (res == null || res == undefined)
        return;
      else {
        this._msg.open(res, '', { duration: 2000, horizontalPosition: 'center', verticalPosition: 'top' })
        return this.readTransactions()
      }
    });
  }

  deleteTransaction(transaction: Transaction) {
    this._appService.postItems('Transaction/deleteTransaction', transaction).subscribe((response: DtoDefaultResponse) => {
      if (response != null || response != undefined)
        return this.readTransactions()
    })
  }
}
