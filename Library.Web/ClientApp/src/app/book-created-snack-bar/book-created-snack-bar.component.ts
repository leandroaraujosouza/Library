import { Component, OnInit } from "@angular/core";
import { MatSnackBarRef } from "@angular/material/snack-bar";

@Component({
  selector: "app-book-created-snack-bar",
  templateUrl: "./book-created-snack-bar.component.html",
  styleUrls: ["./book-created-snack-bar.component.css"],
})
export class BookCreatedSnackBarComponent implements OnInit {
  constructor(
    private snackBarRef: MatSnackBarRef<BookCreatedSnackBarComponent>
  ) {}

  ngOnInit() {}

  close() {
    this.snackBarRef.dismiss();
  }
}
