import { Component, OnInit, Inject, inject } from '@angular/core';

import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

import { ApitrademarkService } from 'src/app/services/apitrademark.service';
import { Trademark } from 'src/app/models/trademark';

@Component({
  selector: 'app-dialogtrademark',
  templateUrl: './dialogtrademark.component.html',
  styleUrls: ['./dialogtrademark.component.css']
})

export class DialogtrademarkComponent implements OnInit {

  public tmId: number;
  public tmName: string;

  constructor(
    public dialogRef: MatDialogRef<DialogtrademarkComponent>,
    public apiTrademark: ApitrademarkService,
    public snackBar: MatSnackBar,

    @Inject(MAT_DIALOG_DATA) public trademark: Trademark
  ) {
      if(this.trademark != null){
        this.tmName = trademark.TmName;
      }
   }

  ngOnInit(): void {
    this.dialogRef.updateSize('auto', 'auto');
  }

  close(){
    this.dialogRef.close();
  }

  addTrademark(){
    const trademark: Trademark = {
      TmId: 0, TmName: this.tmName
    };
    this.apiTrademark.addTrademark(trademark).subscribe(response => {
      if(response.success){
        this.dialogRef.close();
        this.snackBar.open('Record saved successfully!', '', {
          duration: 3000
        });
      }
    });
  }

  editTrademark(){
    const trademark: Trademark = {
      TmId: this.tmId, TmName: this.tmName
    };
    this.apiTrademark.editTrademark(trademark).subscribe(response => {
      if(response.success){
        this.dialogRef.close();
        this.snackBar.open('Changes saved successfully!', '', {
          duration: 3000
        });
      }
    });
  }
}
