import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: "app-book",
  templateUrl: "./book.component.html",
  styleUrls: ["./book.component.css"],
})
export class BookComponent implements OnInit {
  title = new FormControl("", [Validators.required]);
  author = new FormControl("", [Validators.required]);
  isbn = new FormControl("", [Validators.required]);
  releaseDate = new FormControl("", [Validators.required]);

  constructor() {}

  ngOnInit() {}
}
