import { Component, OnInit } from '@angular/core';
import { ApiclientService } from '../services/apiclient.service';
import { ApiResponse } from '../models/api-response';
import { DialogClientComponent } from './dialog/dialog-client.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.scss']
})
export class ClientComponent implements OnInit {
  public clients: any[] = [];
  public columns: string[] = ['id', 'name'];
  constructor(
    private apiClient: ApiclientService,
    public dialog: MatDialog
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
      DialogClientComponent, { width: '600' }
    );
    dialogRef.afterClosed().subscribe(result =>{
      this.getClients();
    });
  }

}
