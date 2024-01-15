import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
import { Quote } from './models';

@Injectable({
  providedIn: 'root'
})
export class QuoteService {

  private baseUrl = "https://localhost:7258"
  constructor(@Inject (HttpClient) private http: HttpClient) { }

  async getAllQuotes() {
    const url = `${this.baseUrl}/api/quotes`;
    return await firstValueFrom(this.http.get<Quote[]>(url));
  }

  async getQuote(id: number) {
    const url = `${this.baseUrl}/api/quotes/${id}`;
    return await firstValueFrom(this.http.get<Quote>(url));
  }

  async deleteQuote(id: number) {
    const url = `${this.baseUrl}/api/quotes/${id}`;
    return await firstValueFrom(this.http.delete<Quote>(url));
  }

  async getRandomQuote() {
    const url = `${this.baseUrl}/api/quotes/random`;
    return await firstValueFrom(this.http.get<Quote>(url));
  }

  async searchQuotes(searchTerm: string) {
    const url = `${this.baseUrl}/api/quotes/search/${searchTerm}`;
    return await firstValueFrom(this.http.get<Quote[]>(url));
  }
}
