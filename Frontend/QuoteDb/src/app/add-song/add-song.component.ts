import { Component, Inject } from '@angular/core';
import { SongRequest } from '../models';
import { SongService } from '../song.service';
import { FormGroup, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
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
    title: new FormControl<string>('', [Validators.required]),
    album: new FormControl<string>(''),
    artist: new FormControl<string | null>('', [Validators.required]),
    track: new FormControl<number | null>(null),
    text: new FormControl<string>('', [Validators.required]),
  });

  get title() {
    return this.songForm.get('title')!;
  }

  get artist() {
    return this.songForm.get('artist')!;
  }

  get text() {
    return this.songForm.get('text')!;
  }

  async onSubmit() {
    console.log(this.songForm.value);

    const songRequest = this.songForm.value as SongRequest;
    try {
      if(this.songForm.valid) {
        await this.service.createSong(songRequest);
        this.songForm.reset();
        this.showSaved = true;
        this.showError = false;
      } else {
        console.log('Form is invalid');
      }
    } catch (ex) {
      console.log(ex);
      this.showError = true;
      this.showSaved = false;
    }
  }
}