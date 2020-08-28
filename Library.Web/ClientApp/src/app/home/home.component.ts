import { Component, OnInit } from "@angular/core";

export class Book {
  public title: string;
  public isbn: string;

  constructor(title: string, isbn: string) {
    this.title = title;
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
export class HomeComponent implements OnInit {
  constructor() {}

  public books: Array<Book> = [];

  ngOnInit(): void {
    this.books.push(new Book("Book 1", "ABC123"));
    this.books.push(new Book("Book 2", "ABC123"));
    this.books.push(new Book("Book 3", "ABC123"));
    this.books.push(new Book("Book 4", "ABC123"));
    this.books.push(new Book("Book 5", "ABC123"));
    this.books.push(new Book("Book 6", "ABC123"));
  }
}