import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BookCreatedSnackBarComponent } from './book-created-snack-bar.component';

describe('BookCreatedSnackBarComponent', () => {
  let component: BookCreatedSnackBarComponent;
  let fixture: ComponentFixture<BookCreatedSnackBarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BookCreatedSnackBarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BookCreatedSnackBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
