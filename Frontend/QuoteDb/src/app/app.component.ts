import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';
import { QuoteService } from './quote.service';
import { Quote, QuoteType } from './models';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterLink],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(@Inject(QuoteService) private service: QuoteService) {}

  title = 'QuoteDb';
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
