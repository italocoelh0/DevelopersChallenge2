import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IndexComponent } from './page/index/index.component';
import { ImportDataComponent } from './page/import-data/import-data.component';
import { NavComponent } from './component/nav/nav.component';
import { AppService } from './services/app.service';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatPaginatorModule } from '@angular/material/paginator';
import { ReadAccountsComponent } from './page/account/read-accounts/read-accounts.component';
import { CreateAccountComponent } from './page/account/create-account/create-account.component';
import { UpdateAccountComponent } from './page/account/update-account/update-account.component';
import { CreateTransactionComponent } from './page/transaction/create-transaction/create-transaction.component';
import { ReadTransactionComponent } from './page/transaction/read-transaction/read-transaction.component';
import { UpdateTransactionComponent } from './page/transaction/update-transaction/update-transaction.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { AboutComponent } from './page/about/about.component';

@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    ImportDataComponent,
    NavComponent,
    ReadAccountsComponent,
    CreateAccountComponent,
    UpdateAccountComponent,
    CreateTransactionComponent,
    ReadTransactionComponent,
    UpdateTransactionComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatDatepickerModule,
    MatFormFieldModule,
    FormsModule,
    MatPaginatorModule,
    MatSnackBarModule
  ],
  providers: [
    AppService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
