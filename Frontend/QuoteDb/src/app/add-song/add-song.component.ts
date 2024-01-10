import { Component, Inject } from '@angular/core';
import { SongRequest } from '../models';
import { SongService } from '../song.service';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-song',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './add-song.component.html',
  styleUrl: './add-song.component.css'
})
export class AddSongComponent {

  constructor(@Inject(SongService) private service: SongService) {}

  songForm = new FormGroup({
    title: new FormControl<string>(''),
    album: new FormControl<string>(''),
    artist: new FormControl<string | null>(''),
    track: new FormControl<number | null>(0),
    text: new FormControl<string>(''),
  });

  onSubmit() {
    console.log(this.songForm.value);

    const songRequest = this.songForm.value as SongRequest;
    this.service.createSong(songRequest);
  }

}
