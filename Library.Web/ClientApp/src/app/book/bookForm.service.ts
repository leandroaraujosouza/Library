import { HttpClient } from "@angular/common/http";
import { Injectable, Inject } from "@angular/core";

@Injectable()
export class BookFormService {
  bookAdded: Book;

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  add(book: Book) {
    this.http.post<Book>(this.baseUrl + "Books/Add", book).subscribe(
      (result) => {
        this.bookAdded = result;
      },
      (error) => console.error(error)
    );
  }
}

interface Book {
  title: string;
  author: string;
  isbn: string;
  releaseDate: string;
}
