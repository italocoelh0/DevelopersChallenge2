import { Component, OnInit } from '@angular/core';
import { Account, AccountModel } from 'src/app/models/account.interface';
import { AppService } from 'src/app/services/app.service';
import { MatDialogRef } from '@angular/material/dialog';
import { DtoDefaultResponse } from 'src/app/models/dto-default-response.interface';


@Component({
  selector: 'NiboAngularSPA-create-account',
  templateUrl: './create-account.component.html',
  styleUrls: ['./create-account.component.css']
})
export class CreateAccountComponent implements OnInit {
  accountObj: Account = new AccountModel()
  accType: string
  bnkId: string

  constructor(private _dialRef: MatDialogRef<CreateAccountComponent>, private _appService: AppService) {
  }

  ngOnInit(): void {
  }

  onFormSubmit(valid) {
    if (valid){
      this.accountObj.accountType = this.accType
      this.accountObj.bankId = parseInt(this.bnkId)
      this._appService.postItems('Account/createAccount', this.accountObj).subscribe((response : DtoDefaultResponse) => {
        if(response != null){
          return this.closeDialog(response.message);
        }
      })
    }

  }

  closeDialog(value?) {
    return this._dialRef.close(value)
  }
}
