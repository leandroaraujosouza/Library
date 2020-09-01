import { HttpClient } from "@angular/common/http";
import { Injectable, Inject } from "@angular/core";

@Injectable()
export class BookFormService {
  books: Object;

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  add(book: Book) {
    return this.http.post<Book>(this.baseUrl + "books/add", book);
  }

  get(id: string) {
    return this.http.get(this.baseUrl + `books/get?id=${id}`);
  }

  edit(id: string, book: any) {
    return this.http.put(this.baseUrl + `books/edit?id=${id}`, book);
  }

  delete(id: string) {
    return this.http.delete(this.baseUrl + `books/delete?id=${id}`);
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
