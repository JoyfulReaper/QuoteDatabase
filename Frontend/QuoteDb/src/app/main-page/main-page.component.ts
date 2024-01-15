import { Component, Inject } from '@angular/core';
import { QuoteService } from '../quote.service';
import { Quote, QuoteType } from '../models';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-main-page',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.css'
})
export class MainPageComponent {
  constructor(@Inject(QuoteService) private service: QuoteService) {}

  quote: Quote = new Quote();
  quoteType: string;
  quoteLink: string;

  async ngOnInit() {
    await this.getRandomQuote();
  }

  async getRandomQuote() {
    this.quote = await this.service.getRandomQuote();
    this.quoteType = QuoteType[this.quote.quoteType];
    switch (this.quote.quoteType) {
      case QuoteType.Book:
        this.quoteLink = `/quotes/books/`;
        break;
      case QuoteType.Movie:
        this.quoteLink = `/quotes/movies/`;
        break;
      case QuoteType.Person:
        this.quoteLink = `/quotes/people/`;
        break;
      case QuoteType.Song:
        this.quoteLink = `/quotes/songs/`;
        break;
    }
  }
}
