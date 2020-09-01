import { BookCreatedSnackBarComponent } from "./../book-created-snack-bar/book-created-snack-bar.component";
import { BookService } from "./bookForm.service";
import {
  Component,
  OnInit,
  ViewChild,
  ElementRef,
  AfterContentInit,
} from "@angular/core";
import { FormControl, FormGroup, Validators, NgForm } from "@angular/forms";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { Book } from "../home/home.component";

@Component({
  selector: "app-book",
  templateUrl: "./bookForm.component.html",
  styleUrls: ["./bookForm.component.css"],
})
export class BookComponent implements OnInit, AfterContentInit {
  formGroup: FormGroup;
  isValidFormSubmitted = null;
  book: any;

  @ViewChild("bookName", { static: false }) bookName: ElementRef;
  @ViewChild("form", { static: false }) private form: NgForm;
  bookId: string;

  constructor(
    private bookService: BookService,
    private _snackBar: MatSnackBar,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.route.paramMap.subscribe((params) => {
      this.bookId = params.get("id");
    });
  }

  ngAfterContentInit(): void {}

  onFormSubmit() {
    this.isValidFormSubmitted = false;
    if (this.formGroup.invalid) {
      return;
    }
    this.isValidFormSubmitted = true;
    this.book = this.formGroup.value;

    if (this.bookId) {
      this.bookService.edit(this.bookId, this.book).subscribe((book) => {
        this.router.navigate(["/"]);
      });
    } else {
      this.bookService.add(this.book).subscribe((book) => {
        this.displaySuccessMessage();
      });
    }

    this.form.resetForm();
  }

  displaySuccessMessage() {
    this._snackBar.openFromComponent(BookCreatedSnackBarComponent, {
      horizontalPosition: "start",
      panelClass: ["mat-elevation-z3"],
      duration: 3000,
    });
  }

  ngOnInit() {
    //Init FORM
    this.formGroup = new FormGroup({
      name: new FormControl("", [Validators.required, Validators.minLength(2)]),
      authorName: new FormControl("", [Validators.required]),
      isbn: new FormControl("", [Validators.required]),
      releaseDate: new FormControl("", [Validators.required]),
    });

    if (this.bookId) {
      this.bookService.get(this.bookId).subscribe((book: Book) => {
        this.name.setValue(book.name);
        this.authorName.setValue(book.authorName);
        this.isbn.setValue(book.isbn);
        this.releaseDate.setValue(book.releaseDate);
      });
    }
  }

  get authorName() {
    return this.formGroup.get("authorName");
  }
  get name() {
    return this.formGroup.get("name");
  }
  get isbn() {
    return this.formGroup.get("isbn");
  }
  get releaseDate() {
    return this.formGroup.get("releaseDate");
  }
}
