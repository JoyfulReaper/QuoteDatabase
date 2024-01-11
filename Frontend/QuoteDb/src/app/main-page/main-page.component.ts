import { Component, Inject } from '@angular/core';
import { QuoteService } from '../quote.service';
import { Quote, QuoteType } from '../models';

@Component({
  selector: 'app-main-page',
  standalone: true,
  imports: [],
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.css'
})
export class MainPageComponent {
  constructor(@Inject(QuoteService) private service: QuoteService) {}

  quote: Quote = new Quote();
  type: string;

  async ngOnInit() {
    await this.getRandomQuote();
  }

  async getRandomQuote() {
    this.quote = await this.service.getRandomQuote();
    this.type = QuoteType[this.quote.quoteType];
  }
}
