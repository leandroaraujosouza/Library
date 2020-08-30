import { BookFormService } from "./../book/bookForm.service";
import { Component, OnInit } from "@angular/core";

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
  providers: [BookFormService],
})
export class HomeComponent implements OnInit {
  constructor(private bookService: BookFormService) {}

  public books: any;

  ngOnInit(): void {
    this.bookService.getAll().subscribe((result) => {
      this.books = result;
    });
  }
}
