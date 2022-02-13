import { Component } from "@angular/core";
import { MatDialogRef } from "@angular/material/dialog";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Client } from "src/app/models/client";
import { ApiclientService } from "../../services/apiclient.service";

@Component({
    templateUrl: 'dialog-client.component.html'
})
export class DialogClientComponent {
    public name: string = '';
    constructor(public dialogRef: MatDialogRef<DialogClientComponent>,
        public apiClient: ApiclientService,
        public snackBar: MatSnackBar
    ) { }

    close() {
        this.dialogRef.close();
    }

    addClient() {
        const client: Client = { name: this.name };
        this.apiClient.add(client).subscribe(
            response => {
                if (response.success === 1) {
                    this.dialogRef.close();
                    this.snackBar.open("Cliente agregado con exito.", '',
                        { duration: 2000 });
                }
            }
        );
    }
}