import { EventEmitter } from "events";
import { BookService } from "../../../book/book.service";
import { Component, OnInit, Inject, Output } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";

@Component({
  selector: "app-delete-confirmation",
  templateUrl: "./delete-confirmation.component.html",
  styleUrls: ["./delete-confirmation.component.css"],
})
export class DeleteConfirmationComponent implements OnInit {
  @Output()
  public bookDeleted: EventEmitter = new EventEmitter();
  constructor(
    @Inject(MAT_DIALOG_DATA) public book: any,
    private bookService: BookService,
    private dialogRef: MatDialogRef<DeleteConfirmationComponent>
  ) {}

  ngOnInit() {}

  delete(id: string) {
    this.bookService.delete(id).subscribe(
      () => {
        this.dialogRef.close(id);
      },
      () => {}
    );
  }
}
