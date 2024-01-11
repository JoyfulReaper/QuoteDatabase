import { Component, Inject } from '@angular/core';
import { SongRequest } from '../models';
import { SongService } from '../song.service';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-song',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './add-song.component.html',
  styleUrl: './add-song.component.css'
})
export class AddSongComponent {

  constructor(@Inject(SongService) private service: SongService) {}

  showError = false;
  showSaved = false;

  songForm = new FormGroup({
    title: new FormControl<string>(''),
    album: new FormControl<string>(''),
    artist: new FormControl<string | null>(''),
    track: new FormControl<number | null>(null),
    text: new FormControl<string>(''),
  });

  async onSubmit() {
    console.log(this.songForm.value);

    const songRequest = this.songForm.value as SongRequest;
    try {
      await this.service.createSong(songRequest);
      this.songForm.reset();
      this.showSaved = true;
      this.showError = false;
    } catch (ex) {
      console.log(ex);
      this.showError = true;
      this.showSaved = false;
    }
  }
}
