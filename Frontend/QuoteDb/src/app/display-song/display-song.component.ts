import { Component, Inject, Input } from '@angular/core';
import { SongService } from '../song.service';
import { Song } from '../models';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-display-song',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './display-song.component.html',
  styleUrl: './display-song.component.css'
})
export class DisplaySongComponent {
  constructor(@Inject(SongService) private service: SongService) {}

  song: Song;

  @Input()
  set id(quoteId: number) {
    this.service.getSong(quoteId).then(song => this.song = song);
  }
}
