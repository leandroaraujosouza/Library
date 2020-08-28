import { BookFormService } from "./bookForm.service";
import {
  Component,
  OnInit,
  ViewChild,
  ElementRef,
  AfterContentInit,
} from "@angular/core";
import { FormControl, FormGroup, Validators, NgForm } from "@angular/forms";

@Component({
  selector: "app-book",
  templateUrl: "./bookForm.component.html",
  styleUrls: ["./bookForm.component.css"],
  providers: [BookFormService],
})
export class BookComponent implements OnInit, AfterContentInit {
  formGroup: FormGroup;
  isValidFormSubmitted = null;
  book: any;

  @ViewChild("bookName", { static: false }) bookName: ElementRef;
  @ViewChild("form", { static: false }) private form: NgForm;

  constructor(private bookFormService: BookFormService) {}

  ngAfterContentInit(): void {}

  onFormSubmit() {
    this.isValidFormSubmitted = false;
    if (this.formGroup.invalid) {
      return;
    }
    this.isValidFormSubmitted = true;
    this.book = this.formGroup.value;

    this.bookFormService.add(this.book);

    this.form.resetForm();
  }

  ngOnInit() {
    this.formGroup = new FormGroup({
      name: new FormControl("", [Validators.required, Validators.minLength(2)]),
      authorName: new FormControl("", [Validators.required]),
      isbn: new FormControl("", [Validators.required]),
      releaseDate: new FormControl("", [Validators.required]),
    });
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
