import { HttpClient } from "@angular/common/http";
import { Injectable, Inject } from "@angular/core";

@Injectable()
export class BookFormService {
  bookAdded: Book;
  books: Object;

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  add(book: Book) {
    this.http.post<Book>(this.baseUrl + "books/add", book).subscribe(
      (result) => {
        this.bookAdded = result;
      },
      (error) => console.error(error)
    );
  }

  delete(bookId: string) {
    this.http.delete(this.baseUrl + `books/delete?id=${bookId}`).subscribe(
      (result) => {},
      (error) => console.log(error)
    );
  }

  getAll() {
    return this.http.get(this.baseUrl + "books/getall");
  }
}

interface Book {
  author: string;
  name: string;
  isbn: string;
  releaseDate: string;
}
