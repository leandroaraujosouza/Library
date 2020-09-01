import { DeleteConfirmationComponent } from "./../home/delete-confirmation/delete-confirmation/delete-confirmation.component";
import { MatSnackBarRef } from "@angular/material/snack-bar";
import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { BookCreatedSnackBarComponent } from "./book-created-snack-bar.component";
import { CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from "@angular/core";
import { MAT_DIALOG_DATA } from "@angular/material/dialog";

describe("BookCreatedSnackBarComponent", () => {
  let component: BookCreatedSnackBarComponent;
  let fixture: ComponentFixture<BookCreatedSnackBarComponent>;
  let mockMatSnackBarRef;

  beforeEach(async(() => {
    mockMatSnackBarRef = jasmine.createSpyObj(["dismiss"]);
    TestBed.configureTestingModule({
      declarations: [BookCreatedSnackBarComponent],
      schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA],
      providers: [{ provide: MatSnackBarRef, userValue: mockMatSnackBarRef }],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BookCreatedSnackBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
