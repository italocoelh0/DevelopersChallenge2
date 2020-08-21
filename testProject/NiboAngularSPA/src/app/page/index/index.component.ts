import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Transaction, TransactionModel } from 'src/app/models/transaction.interface';
import { AppService } from 'src/app/services/app.service'
import { DtoDataSelect, DataSelectModel } from 'src/app/models/dto-data-select.interface';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  pageObj : Array<Transaction> = new Array<TransactionModel>();
  filterObj : DtoDataSelect = new DataSelectModel;
  constructor(private _router : Router, private _appService : AppService) { }

  ngOnInit(): void {
    this.searchItens()
  }

  searchItens(){
    this._appService.postItems('/getTransactions', this.filterObj).subscribe((response : Array<Transaction>) => {
      this.pageObj = response;
    })
  }
}
