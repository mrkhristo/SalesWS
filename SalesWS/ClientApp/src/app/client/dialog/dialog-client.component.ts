import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Client } from "src/app/models/client";
import { ApiclientService } from "../../services/apiclient.service";

@Component({
    templateUrl: 'dialog-client.component.html'
})
export class DialogClientComponent {
    public name: string = '';

    constructor(
        public dialogRef: MatDialogRef<DialogClientComponent>,
        public apiClient: ApiclientService,
        public snackBar: MatSnackBar,
        @Inject(MAT_DIALOG_DATA) public client: Client
    ) {
        if (this.client !== null) {
            this.name = client.name;
        }

    }

    close() {
        this.dialogRef.close();
    }

    addClient() {
        const client: Client = { name: this.name, id: 0 };
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
    editClient() {
        const client: Client = { name: this.name, id: this.client.id };
        this.apiClient.edit(client).subscribe(
            response => {
                if (response.success === 1) {
                    this.dialogRef.close();
                    this.snackBar.open("Cliente editado con exito.", '',
                        { duration: 2000 });
                }
            }
        );
    }
}