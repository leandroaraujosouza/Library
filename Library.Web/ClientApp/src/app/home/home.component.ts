import { BookService } from "../book/book.service";
import { Component, OnInit, OnDestroy, Input } from "@angular/core";
import { DeleteConfirmationComponent } from "./delete-confirmation/delete-confirmation/delete-confirmation.component";
import { MatDialog } from "@angular/material/dialog";

export class Book {
  public name: string;
  public authorName: string;
  public isbn: string;
  public releaseDate: Date;

  constructor(title: string, isbn: string) {
    this.name = title;
    this.isbn = isbn;
  }
}
/**
 * @title Basic grid-list
 */
@Component({
  selector: "app-home",
  styleUrls: ["home.component.css"],
  templateUrl: "home.component.html",
})
export class HomeComponent implements OnInit, OnDestroy {
  @Input()
  dialogRef: any;
  constructor(private bookService: BookService, public dialog: MatDialog) {}

  public books: any;

  ngOnInit(): void {
    this.bookService.getAll().subscribe((result) => {
      this.books = result;
    });
  }

  ngOnDestroy(): void {
    if (this.dialogRef !== undefined) this.dialogRef._afterClosed.unsubscribe();
  }

  onDelete(id: string) {
    const index = this.books.findIndex((book) => book.id === id);
    this.books.splice(index, 1);
  }

  openDeleteConfirmationDialog(id: string) {
    this.dialogRef = this.dialog.open(DeleteConfirmationComponent, {
      data: this.books.filter((book) => book.id == id)[0],
    });

    this.dialogRef.afterClosed().subscribe((id) => {
      if (id) {
        this.onDelete(id);
      }
    });
  }
}
