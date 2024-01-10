import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
import { Movie, MovieRequest } from './models';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  private baseUrl = "https://localhost:7258"
  constructor(@Inject (HttpClient) private http: HttpClient) { }

  async getAllMovies() {
    const url = `${this.baseUrl}/api/quotes/movies`;
    return await firstValueFrom(this.http.get<Movie[]>(url));
  }

  async getMovie(id: number) {
    const url = `${this.baseUrl}/api/quotes/movies/${id}`;
    return await firstValueFrom(this.http.get<Movie>(url));
  }

  async createBook(movie: MovieRequest) {
    const url = `${this.baseUrl}/api/quotes/movies`;
    return await firstValueFrom(this.http.post<MovieRequest>(url, movie));
  }

  async updateBook(movie: Movie) {
    const url = `${this.baseUrl}/api/quotes/movies/${movie.quoteId}`;
    return await firstValueFrom(this.http.put<Movie>(url, movie));
  }

  async deleteBook(id: number) {
    const url = `${this.baseUrl}/api/quotes/movies/${id}`;
    return await firstValueFrom(this.http.delete<Movie>(url));
  }
}
