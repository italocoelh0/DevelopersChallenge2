import { Component, OnInit } from '@angular/core';
import { DtoImportFiles, DtoImportFilesModel } from 'src/app/models/dto-import-files.interface';
import { MatDialogRef } from '@angular/material/dialog';
import { AppService } from 'src/app/services/app.service';
import { DtoDefaultResponse } from 'src/app/models/dto-default-response.interface';

@Component({
  selector: 'NiboAngularSPA-import-data',
  templateUrl: './import-data.component.html',
  styleUrls: ['./import-data.component.css']
})
export class ImportDataComponent implements OnInit {
  pageObj: DtoImportFiles = new DtoImportFilesModel;

  constructor(private _dialRef: MatDialogRef<ImportDataComponent>, private _appService: AppService) { }

  ngOnInit() {
  }

  selectFiles(event) {
    for (let i = 0; i < event.target.files.length; i++) {
      let reader = new FileReader();
      let file = event.target.files[i];
      reader.readAsDataURL(file);
      reader.onload = () => {
        if (this.pageObj) {
          let readerRes = reader.result
          if (readerRes.toString().split(',').length > 1)
            this.pageObj.fileList.push(readerRes.toString().split(',')[1])
          else
            alert('Ocorreu um erro ao tentar selecionar o arquivo ' + file.name)
        }

      };
    }
  }

  uploadFiles() {
    if (this.pageObj.fileList.length == 0)
      this.closeDialog('Selecione ao menos um arquivo para importação.')
    this._appService.postItems('Transaction/importFile', this.pageObj).subscribe((response: DtoDefaultResponse) => {
      return this.closeDialog(response.message)
    })
  }

  closeDialog(value?){
    return this._dialRef.close(value)
  }
}
