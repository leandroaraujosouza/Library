import { BookService } from "./book.service";
import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { BookComponent } from "./bookForm.component";

describe("BookComponent", () => {
  let component: BookComponent;
  let fixture: ComponentFixture<BookComponent>;
  let mockBookService;

  beforeEach(async(() => {
    mockBookService = jasmine.createSpyObj(["edit", "add"]);
    TestBed.configureTestingModule({
      declarations: [BookComponent],
      providers: [{ provide: BookService, useValue: mockBookService }],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
