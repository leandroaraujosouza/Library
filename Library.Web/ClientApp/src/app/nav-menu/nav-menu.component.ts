import { Component } from "@angular/core";

/**
 * @title Basic toolbar
 */
@Component({
  selector: "app-navbar",
  templateUrl: "nav-menu.component.html",
  styleUrls: ["nav-menu.component.css"],
})
export class NavMenuComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
