import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
import { Song, SongRequest } from './models';

@Injectable({
  providedIn: 'root'
})
export class SongService {
  private baseUrl = "https://localhost:7258"
  constructor(@Inject (HttpClient) private http: HttpClient) { }

  async getAllSongs() {
    const url = `${this.baseUrl}/api/quotes/songs`;
    return await firstValueFrom(this.http.get<Song[]>(url));
  }

  async getSong(id: number) {
    const url = `${this.baseUrl}/api/quotes/songs/${id}`;
    return await firstValueFrom(this.http.get<Song>(url));
  }

  async createSong(song: SongRequest) {
    const url = `${this.baseUrl}/api/quotes/songs`;
    return await firstValueFrom(this.http.post<Song>(url, song));
  }

  async updateSong(song: Song) {
    const url = `${this.baseUrl}/api/quotes/songs/${song.quoteId}`;
    return await firstValueFrom(this.http.put<Song>(url, song));
  }

  async deleteSong(id: number) {
    const url = `${this.baseUrl}/api/quotes/songs/${id}`;
    return await firstValueFrom(this.http.delete<Song>(url));
  }
}