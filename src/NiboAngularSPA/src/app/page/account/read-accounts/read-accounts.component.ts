import { Component, OnInit } from '@angular/core';
import { Account, AccountModel } from 'src/app/models/account.interface';
import { PageEvent } from '@angular/material/paginator';
import { AppService } from 'src/app/services/app.service';
import { CreateAccountComponent } from '../create-account/create-account.component';
import { UpdateAccountComponent } from '../update-account/update-account.component';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DtoDefaultResponse } from 'src/app/models/dto-default-response.interface';

@Component({
  selector: 'NiboAngularSPA-read-accounts',
  templateUrl: './read-accounts.component.html',
  styleUrls: ['./read-accounts.component.css']
})
export class ReadAccountsComponent implements OnInit {
  accountsObj: Array<Account> = new Array<AccountModel>()
  pagedResult: Array<Account>

  constructor(private _appService: AppService, private _dial: MatDialog, private _msg: MatSnackBar) { }

  ngOnInit(): void {
    this.readAccounts()
  }

  onPageChange(event: PageEvent) {
    const startIdx = event.pageIndex * event.pageSize
    let endIdx = startIdx + event.pageSize

    if (endIdx > event.length)
      endIdx = event.length

    this.pagedResult = this.accountsObj.slice(startIdx, endIdx)
  }

  readAccounts() {
    this._appService.postItems('Account/readAccounts', new AccountModel).subscribe((response : Array<Account>) => {
      if(response != null){
        this.accountsObj = response
        this.pagedResult = this.accountsObj.slice(0, 10)
      }
    })
  }

  newAccount(){
    let dial = this._dial.open(CreateAccountComponent, { maxWidth: '750px' });
    dial.afterClosed().subscribe(res => {
      if (res == null || res == undefined)
        return;
      else {
        this._msg.open(res, '', { duration: 2000, horizontalPosition: 'center', verticalPosition: 'top' })
        return this.readAccounts()
      }
    });
  }

  editAccount(account) {
    let dial = this._dial.open(UpdateAccountComponent, { maxWidth: '750px', data: { ...account } });
    dial.afterClosed().subscribe(res => {
      if (res == null || res == undefined)
        return;
      else {
        this._msg.open(res, '', { duration: 2000, horizontalPosition: 'center', verticalPosition: 'top' })
        return this.readAccounts()
      }
    });
  }

  deleteAccount(account) {
    this._appService.postItems('Account/deleteAccount', account).subscribe((response: DtoDefaultResponse) => {
      if (response != null || response != undefined)
        return this.readAccounts()
    })
  }
}
