import { Component, OnInit, Inject } from '@angular/core';
import { Account, AccountModel } from 'src/app/models/account.interface';
import { AppService } from 'src/app/services/app.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DtoDefaultResponse } from 'src/app/models/dto-default-response.interface';

@Component({
  selector: 'NiboAngularSPA-update-account',
  templateUrl: './update-account.component.html',
  styleUrls: ['./update-account.component.css']
})
export class UpdateAccountComponent implements OnInit {
  accountObj: Account = new AccountModel()
  accType: string
  bnkId: string

  constructor(@Inject(MAT_DIALOG_DATA) public _data: Account, private _dialRef: MatDialogRef<UpdateAccountComponent>, private _appService: AppService) {
  }

  ngOnInit(): void {
    if (this._data != undefined && this._data != null) {
      this.accType = this._data.accountType
      this.bnkId = this._data.bankId.toString()
    }
  }

  onFormSubmit(valid) {
    if (valid) {
      this.accountObj.accountType = this.accType
      this.accountObj.bankId = parseInt(this.bnkId)
      this.accountObj.accountId = this._data.accountId
      this._appService.postItems('Account/updateAccount', this.accountObj).subscribe((response: DtoDefaultResponse) => {
        if (response != null) {
          return this.closeDialog(response.message);
        }
      })
    }

  }

  closeDialog(value?) {
    return this._dialRef.close(value)
  }
}
