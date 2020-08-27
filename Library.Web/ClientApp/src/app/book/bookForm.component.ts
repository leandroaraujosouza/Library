import { BookFormService } from "./bookForm.service";
import { Component, OnInit, Input } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: "app-book",
  templateUrl: "./bookForm.component.html",
  styleUrls: ["./bookForm.component.css"],
  providers: [BookFormService],
})
export class BookComponent implements OnInit {
  bookForm = new FormGroup({
    title: new FormControl("", [Validators.required]),
    author: new FormControl("", [Validators.required]),
    isbn: new FormControl("", [Validators.required]),
    releaseDate: new FormControl("", [Validators.required]),
  });

  constructor(private bookFormService: BookFormService) {}

  onSubmit(data) {
    console.log(data);
    this.bookFormService.add({ ...data, releaseDate: data.ge });
  }

  ngOnInit() {}
}
