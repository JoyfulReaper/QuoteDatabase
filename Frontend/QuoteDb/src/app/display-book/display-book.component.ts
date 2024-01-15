import { CommonModule } from '@angular/common';
import { Component, Inject, Input } from '@angular/core';
import { BookService } from '../book.service';
import { Book } from '../models';

@Component({
  selector: 'app-display-book',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './display-book.component.html',
  styleUrl: './display-book.component.css'
})
export class DisplayBookComponent {
  constructor(@Inject(BookService) private service: BookService) {}

  book: Book;

  @Input()
  set id(quoteId: number) {
    this.service.getBook(quoteId).then(book => this.book = book);
  }
}
