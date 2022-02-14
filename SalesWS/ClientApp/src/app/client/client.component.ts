import { Component, OnInit } from '@angular/core';
import { ApiclientService } from '../services/apiclient.service';
import { ApiResponse } from '../models/api-response';
import { DialogClientComponent } from './dialog/dialog-client.component';
import { MatDialog } from '@angular/material/dialog';
import { Client } from '../models/client';
import { DialogDeleteComponent } from '../common/delete/dialog-delete.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.scss']
})
export class ClientComponent implements OnInit {
  public clients: any[] = [];
  public columns: string[] = ['id', 'name','actions'];
  readonly dialogWidth:string='300px';

  constructor(
    private apiClient: ApiclientService,
    public dialog: MatDialog,
    public snackBar: MatSnackBar,
  ) {
  }

  ngOnInit(): void {
    this.getClients();
  }

  getClients() {
    this.apiClient.getAll().subscribe((response: { data: any[]; }) => {
      this.clients = response.data;
    });
  }

  openAdd() {
    const dialogRef = this.dialog.open(
      DialogClientComponent, { width: this.dialogWidth }
    );
    dialogRef.afterClosed().subscribe(result =>{
      this.getClients();
    });
  }

  openEdit(client: Client){
    const dialogRef = this.dialog.open(
      DialogClientComponent, { width: this.dialogWidth, data:client}
    );
    dialogRef.afterClosed().subscribe(result =>{
      this.getClients();
    });
  }

  deleteClient(client:Client){
    const dialogRef = this.dialog.open(
      DialogDeleteComponent, { width: this.dialogWidth}
    );
    dialogRef.afterClosed().subscribe(result =>{
      if(result){
        this.apiClient.delete(client.id).subscribe( response =>{
          if(response.success === 1){
            this.getClients();
            this.snackBar.open("Cliente eliminado con exito.", '',
            { duration: 2000 });
          }
        });
      }
    });
  }
}
