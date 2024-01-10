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
    title: new FormControl(''),
    album: new FormControl(''),
    artist: new FormControl(''),
    track: new FormControl(''),
    text: new FormControl(''),
  });

  onSubmit() {
    console.log(this.songForm.value);

    const songRequest = new SongRequest();
    songRequest.title = this.songForm.value.title ?? "";
    songRequest.album = this.songForm.value.album ?? "";
    songRequest.artist = this.songForm.value.artist ?? "";
    songRequest.track = 0;
    songRequest.text = this.songForm.value.text ?? "";

    this.service.createSong(songRequest);
  }

}
