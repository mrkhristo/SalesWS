import { Component } from "@angular/core";
import { MatDialogRef } from "@angular/material/dialog";
@Component(
{
templateUrl:"dialog-delete.component.html"
})
export class DialogDeleteComponent{
    constructor(
        public dialogRef:MatDialogRef<DialogDeleteComponent>
    ){

    }
}