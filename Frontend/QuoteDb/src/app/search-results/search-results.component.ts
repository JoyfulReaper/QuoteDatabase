import { CommonModule } from '@angular/common';
import { Component, Inject, Input } from '@angular/core';
import { QuoteService } from '../quote.service';
import { Quote, QuoteType } from '../models';

@Component({
  selector: 'app-search-results',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './search-results.component.html',
  styleUrl: './search-results.component.css'
})
export class SearchResultsComponent {
  constructor(@Inject(QuoteService) private service: QuoteService) {}

  quotes: Quote[];

  @Input()
  set searchTerm(searchTerm: string) {
    this.service.searchQuotes(searchTerm).then(quotes => this.quotes = quotes);
  }
}
