import { Component, Inject } from '@angular/core';
import { BookRequest } from '../models';
import { BookService } from '../book.service';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-book',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './add-book.component.html',
  styleUrl: './add-book.component.css'
})
export class AddBookComponent {

  constructor(@Inject(BookService) private service: BookService) {}

  showError = false;
  showSaved = false;

  bookForm = new FormGroup({
    title: new FormControl<string>(''),
    text: new FormControl<string>(''),
    author: new FormControl<string>(''),
    chapter: new FormControl<string | null>(''),
    page: new FormControl<number | null>(null),
  });

  async onSubmit() {
    console.log(this.bookForm.value);

    const bookRequest = this.bookForm.value as BookRequest;
    try {
      await this.service.createBook(bookRequest);
      this.showSaved = true;
      this.showError = false;
      this.bookForm.reset();
    } catch (ex) {
      console.log(ex);
      this.showError = true;
      this.showSaved = false;
    }
  }
}
