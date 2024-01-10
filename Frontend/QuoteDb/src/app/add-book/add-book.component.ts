import { Component, Inject } from '@angular/core';
import { BookRequest } from '../models';
import { BookService } from '../book.service';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-book',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './add-book.component.html',
  styleUrl: './add-book.component.css'
})
export class AddBookComponent {

  constructor(@Inject(BookService) private service: BookService) {}

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
    await this.service.createBook(bookRequest);
  }
}
