import { BookService } from "./../../../book/book.service";
import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { DeleteConfirmationComponent } from "./delete-confirmation.component";
import { CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";

describe("DeleteConfirmationComponent", () => {
  let component: DeleteConfirmationComponent;
  let fixture: ComponentFixture<DeleteConfirmationComponent>;
  let mockBookService;
  let mockMatDialogRef;

  beforeEach(async(() => {
    mockBookService = jasmine.createSpyObj(["delete"]);
    mockMatDialogRef = jasmine.createSpyObj(["close"]);
    TestBed.configureTestingModule({
      declarations: [DeleteConfirmationComponent],
      schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA],
      providers: [
        { provide: MAT_DIALOG_DATA, useValue: "" },
        { provide: BookService, useValue: mockBookService },
        { provide: MatDialogRef, useValue: mockMatDialogRef },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteConfirmationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
