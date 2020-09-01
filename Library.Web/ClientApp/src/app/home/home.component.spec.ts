import { HomeComponent } from "./home.component";

describe("HomeComponent", () => {
  let component: HomeComponent;
  let mockBookService;
  let dialog;
  let BOOKS;

  beforeEach(() => {
    BOOKS = [{ id: "1", name: "Book 1", authorName: "Book 1 Author" }];
  });

  mockBookService = jasmine.createSpyObj(["getAll"]);
  dialog = jasmine.createSpyObj(["open"]);

  component = new HomeComponent(mockBookService, dialog);

  describe("getAll", () => {
    it("should get all the books", () => {
      component.books = BOOKS;

      expect(component.books.length).toBe(1);
    });
  });

  describe("delete", () => {
    it("should remove the indicated book from the books list", () => {
      component.books = BOOKS;

      let bookId = BOOKS[0].id;
      component.onDelete(bookId);

      expect(component.books.length).toBe(0);
    });
  });
});
