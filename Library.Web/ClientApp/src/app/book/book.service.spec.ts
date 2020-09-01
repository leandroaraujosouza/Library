import { Book } from "./../home/home.component";
import { HttpClient } from "@angular/common/http";
import { BookService } from "./book.service";
import { of, Observable } from "rxjs";
import { tap, catchError } from "rxjs/operators";
describe("BookService", () => {
  let service: BookService;
  let mockHttpClient: HttpClient;

  beforeEach(() => {
    mockHttpClient = jasmine.createSpyObj(["get", "post", "delete", "put"]);
    service = new BookService(mockHttpClient, "");
  });

  describe("add", () => {
    // it("should return an observable", () => {
    //   service.add.returnValue(of(true));
    // });
  });
});
