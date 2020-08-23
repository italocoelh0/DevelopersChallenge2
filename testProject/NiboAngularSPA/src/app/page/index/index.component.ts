import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Transaction, TransactionModel } from 'src/app/models/transaction.interface';
import { AppService } from 'src/app/services/app.service'
import { DtoTransactionRead, DtoTransactionReadModel } from 'src/app/models/dto-transaction-read.interface';
import { TransactionType, TransactionTypeModel } from 'src/app/models/transactiontypes.interface';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  constructor(private _router: Router, private _appService: AppService) { }

  ngOnInit(): void {
  }
}
