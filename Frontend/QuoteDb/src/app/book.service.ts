import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
import { Book, BookRequest } from './models';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  private baseUrl = "https://localhost:7258"
  constructor(@Inject (HttpClient) private http: HttpClient) { }

  async getAllBooks() {
    const url = `${this.baseUrl}/api/quotes/books`;
    return await firstValueFrom(this.http.get<Book[]>(url));
  }

  async getBook(id: number) {
    const url = `${this.baseUrl}/api/quotes/books/${id}`;
    return await firstValueFrom(this.http.get<Book>(url));
  }

  async createBook(book: BookRequest) {
    const url = `${this.baseUrl}/api/quotes/books`;
    return await firstValueFrom(this.http.post<BookRequest>(url, book));
  }

  async updateBook(book: Book) {
    const url = `${this.baseUrl}/api/quotes/books/${book.quoteId}`;
    return await firstValueFrom(this.http.put<Book>(url, book));
  }

  async deleteBook(id: number) {
    const url = `${this.baseUrl}/api/quotes/books/${id}`;
    return await firstValueFrom(this.http.delete<Book>(url));
  }
}