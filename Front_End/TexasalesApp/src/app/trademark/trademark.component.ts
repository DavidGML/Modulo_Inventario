import { Component, OnInit } from '@angular/core';

import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar, _SnackBarContainer } from '@angular/material/snack-bar';

import { Response } from '../models/response';
import { Trademark } from '../models/trademark';
import { ApitrademarkService } from '../services/apitrademark.service';
import { DialogtrademarkComponent } from './dialogs/dialogtrademark/dialogtrademark.component';
import { DeletedialogComponent } from '../common/delete/deletedialog/deletedialog.component';

@Component({
  selector: 'app-trademark',
  templateUrl: './trademark.component.html',
  styleUrls: ['./trademark.component.css']
})
export class TrademarkComponent implements OnInit {

  public lst: any[];
  public colms: string[] = ['tmId', 'tmName', "options"];

  readonly width: string = "2500px";

  constructor(
    private apitrademark: ApitrademarkService,
    public snackBar: MatSnackBar,
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getTrademark();
  }

  getTrademark() {
    this.apitrademark.getTrademark().subscribe ( response => {
      this.lst = response.data;
    });
  }

  openAdd(){
    const dialogRef = this.dialog.open(DialogtrademarkComponent);
    dialogRef.afterClosed().subscribe( result => {
      this.getTrademark();
    });
  }

  openEdit(trademark: Trademark){
    const dialogRef = this.dialog.open(DialogtrademarkComponent, {
      data: trademark
    }
    );
    dialogRef.afterClosed().subscribe( result => {
      this.getTrademark();
    });
  }

  openDelete(trademark: Trademark){
    const dialogRef = this.dialog.open(DeletedialogComponent, {
    });
    dialogRef.afterClosed().subscribe( result => {
      if(result) {
        this.apitrademark.deleteTrademark(trademark.TmId).subscribe(response =>{
          if(response.success){
            this.snackBar.open('File Deleted successfully!', '', {
              duration: 3000
            });
              this.getTrademark();
          }
        });
      }
    });
  }
}
