import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IndexComponent } from './page/index/index.component'
import { ImportDataComponent } from './page/import-data/import-data.component';

const routes: Routes = [
  { path: '' , component: IndexComponent },
  { path: 'import' , component: ImportDataComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
