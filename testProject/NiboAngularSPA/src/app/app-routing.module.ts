import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IndexComponent } from './page/index/index.component'
import { ImportDataComponent } from './page/import-data/import-data.component';
import { CreateAccountComponent } from './page/account/create-account/create-account.component';
import { ReadAccountsComponent } from './page/account/read-accounts/read-accounts.component';
import { ReadTransactionComponent } from './page/transaction/read-transaction/read-transaction.component';
import { AboutComponent } from './page/about/about.component';

const routes: Routes = [
  { path: '' , component: IndexComponent },
  { path: 'transaction/read' , component: ReadTransactionComponent},
  { path: 'account/read' , component: ReadAccountsComponent},
  { path: 'about', component: AboutComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
